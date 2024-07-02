#include "stdafx.h"
#include "LZW.h"

#define KEY_SIZE 16
const int TBL_SIZE = (1 << KEY_SIZE) - 1; // Максимальное число, которое помещается в KEY_SIZE битов

/// <summary>
/// Ищет код встреченной цепочки байтов в таблице. 
/// Цепочка представлена кодом последней найденой цепочки и текущим символом.
/// </summary>
/// <param name="iPrefixCode">массив префиксов кодов</param>
/// <param name="cCharacter">массив символов</param>
/// <param name="iNumberOfCodes">количество кодов в таблице</param>
/// <param name="iSearchingPrefixCode">код предыдущей цепочки</param>
/// <param name="cSearchingCharacter">добавленный символ</param>
/// <returns>код в случае успеха и -1, если не найден</returns>
int SearchInStringTable(int *iPrefixCode, unsigned char *cCharacter, int iNumberOfCodes, int iSearchingPrefixCode, unsigned char cSearchingCharacter)
{
	if (iSearchingPrefixCode == -1)
	{
		return cSearchingCharacter;
	}
	else
	{
		for (int i = iSearchingPrefixCode + 1; i < iNumberOfCodes; i++){
			if ((iPrefixCode[i] == iSearchingPrefixCode) && (cCharacter[i] == cSearchingCharacter)) return i;
		}
	}
	return -1;
}

/// <summary>
/// Выводит код размером KEY_SIZE в выходной поток
/// Код не обязан быть кратен байту (например, длиной 10-12-14 бит).
/// Функиця набирает полные байты из остатков предыдущего кода и битов текущего кода и выводит в поток.
/// </summary>
/// <param name="os">выходной поток</param>
/// <param name="iCode">код, который нужно записать в поток</param>
/// <returns>0 при успехе, -1 в случае ошибки</returns>
int OutputCode(ofstream &os, int iCode)
{
	static unsigned char cBuffer;		// для хранения остатков предыдущего кода
	static int iNumberOfBitsInBuffer;	// для хранения длины остатка в битах
	int i2_in_power_NOBI = 1;
	
	// Пишем в поток последний код (остатки битов)
	if (iCode == -1) {
		if (iNumberOfBitsInBuffer != 0) os.put(cBuffer);
		return 0;
	}

	// Собственно кодирование
	if (iCode >= 0) {
		i2_in_power_NOBI <<= iNumberOfBitsInBuffer;
		for (int i = 0; i < KEY_SIZE; i++)
		{
			///  Оптимизировать здесь!
			// Помещаем в буфер биты входного кода
			cBuffer += i2_in_power_NOBI*(iCode % 2);
			iCode /= 2;
			i2_in_power_NOBI *= 2;
			iNumberOfBitsInBuffer++;
			// Если заполнен байт, то пишем его в выходной поток, сбрасываем буфер и начинаем накапливать следующий байт
			if (iNumberOfBitsInBuffer >= 8){
				os.put(cBuffer);
				cBuffer = (unsigned char)0;
				iNumberOfBitsInBuffer = 0;
				i2_in_power_NOBI = 1;
			}
		}
		return 0;
	}
	return -1;
}






/// <summary>
/// Инициализирует таблицу кодов цепочек байтов всеми значениями длины 1 (байтами)
/// </summary>
/// <param name="iaPrefixCode">массив кодов предыдущей цепочки</param>
/// <param name="caCharacter">массив символов</param>
/// <returns>текущее количество кодов в таблице</returns>
int InitializeStringTable(int *iaPrefixCode, unsigned char *caCharacter)
{
	if (iaPrefixCode[0] != -1)
		for (int i = 0; i < 256; i++){
			iaPrefixCode[i] = -1;	// Предыдущих цепочек нет. Это первый байт в цепочке!
			caCharacter[i] = (unsigned char)i;
		}
	return 256;
}

/// <summary>
/// Выполняет компрессию входного потока в выходной 
/// </summary>
/// <param name="is">входной поток</param>
/// <param name="os">выходной поток</param>
/// <returns>0 в случае успеха и -1 при ошибке</returns>
int CompressFile(ifstream &is, ofstream &os)
{
	// Определяем таблицу для кодирования
	int iPrefixCode[TBL_SIZE]{0};
	unsigned char cCharacter[TBL_SIZE];

	unsigned char cCurrentCharacter;
	int iReturnCode;

	// Инициализируем всеми байтами
	int iCurrentPrefixCode = -1;	// Для первого символа в последовательности
	int iNumberOfCodes = InitializeStringTable(iPrefixCode, cCharacter);

	is.get((char&)cCurrentCharacter);
	while (!is.eof()){
		// Код есть в таблице
		if ((iReturnCode = SearchInStringTable(iPrefixCode, cCharacter, iNumberOfCodes, iCurrentPrefixCode, cCurrentCharacter)) >= 0){
			iCurrentPrefixCode = iReturnCode;
		}
		else {
			// Иначе добавляем его в таблицу и увеличиваем количество кодов.
			iPrefixCode[iNumberOfCodes] = iCurrentPrefixCode;
			cCharacter[iNumberOfCodes] = cCurrentCharacter;
			iNumberOfCodes++;
			// Выводим предыдущий код в выходной поток.
			// Таким образом, в потоке всегда коды, которые уже есть в таблице!
			if (OutputCode(os, iCurrentPrefixCode)<0) {
				return -1;
			}
			// Начинаем строить новую цепочку с последнего символа добавленной в словарь цепочки.
			iCurrentPrefixCode = (unsigned int)cCurrentCharacter;
		}

		if (iNumberOfCodes >= TBL_SIZE){
			// Если таблица заполнена, то ее нужно переинициализировать.
			if (OutputCode(os, iCurrentPrefixCode)<0) {
				return -1;
			}
			// Выводим признак перехода к новой таблице
			if (OutputCode(os, TBL_SIZE)<0) { // code for overflowing of string table = (TABLE_SIZE-1)+1;
				return -1;
			}

			// Начинаем формировать таблицу кодов сначала!
			iNumberOfCodes = InitializeStringTable(iPrefixCode, cCharacter);
			iCurrentPrefixCode = -1;
		}
		is.get((char&)cCurrentCharacter);
	}
	// Записываем текущий код
	if (OutputCode(os, iCurrentPrefixCode)<0) {
		return -1;
	}
	// Записываем последние биты послдеднего кода
	if (OutputCode(os, -1)<0) {
		return -1;
	}
	return 0;
}



/// <summary>
/// Код в файле соответствутет цепочке байтов
/// Функция получает первый символ этой цепочки
/// </summary>
/// <param name="iPrefixCode">массив префиксов</param>
/// <param name="cCharacter">массив символов (таблицы)</param>
/// <param name="iCurrentCode">Текущий код</param>
/// <returns>1-вый символ цепочки, соответствующей коду</returns>
unsigned char GetFirstCharacterForCode(int *iPrefixCode, unsigned char *cCharacter, int iCurrentCode)
{
	//Итерируем по таблице префиксов, пока не нашли -1.
	while (iPrefixCode[iCurrentCode] >= 0){
		iCurrentCode = iPrefixCode[iCurrentCode];
	}
	//Символ с этим номером и соответствует первому символу цепочки.
	return (cCharacter[iCurrentCode]);
}

/// <summary>
/// Выводит последовательность байтов для данного кода в поток.
/// Цепочка представлена последним юайтом и кодом предвдущей цепочки
/// </summary>
/// <param name="iaPrefixCode">массив кодов предыдущей цепочки</param>
/// <param name="caCharacter">массив последних байтов цепочек</param>
/// <param name="os">выходной поток</param>
/// <param name="iCurrentCode">код последовательности</param>
/// <returns>0 в случае успеха и -1 в случае ошибки</returns>
int OutputStringForCode(int *iPrefixCode, unsigned char *cCharacter, ofstream &os, int iCurrentCode)
{
	static string sOutputString;
	if (iCurrentCode >= 0){
		int iCode = iCurrentCode;
		int iLengthOfString = 0;
		while (iPrefixCode[iCode] >= 0){
			iCode = iPrefixCode[iCode];
			iLengthOfString++;
		}
		sOutputString.resize(iLengthOfString + 1);
		iCode = iCurrentCode;
		for (int i = iLengthOfString; i >= 0; i--){
			sOutputString[i] = cCharacter[iCode];
			iCode = iPrefixCode[iCode];
		}
		os.write((char*)sOutputString.c_str(), iLengthOfString + 1);
		return 0;
	}
	else return -1;
}

/// <summary>
/// Читает очередной код последовательности из потока
/// Обратная операция для OutputCode.
/// </summary>
/// <param name="is">входной поток</param>
/// <returns>код</returns>
int GetNextCodeFromFile(ifstream &is)
{
	static unsigned char cBuffer;
	static int iNumberOfBitsInBuffer = 0;

	int i2_in_power_i = 1;
	int iCode = 0;
	int i = 0;
	for (int i = 0; i<KEY_SIZE; i++){
		if (iNumberOfBitsInBuffer == 0){
			is.get((char&)cBuffer);
			if (is.eof())
				return -1;
			iNumberOfBitsInBuffer = 8;
		}
		iCode += (cBuffer % 2)*i2_in_power_i;
		cBuffer /= 2;
		iNumberOfBitsInBuffer--;
		i2_in_power_i *= 2;
	}
	return iCode;
}

/// <summary>
/// Выполняет декомпрессию входного потока lzw в выходной
/// </summary>
/// <param name="is">входной поток</param>
/// <param name="os">выходной поток</param>
/// <returns>0 при успехе, -1 в случае ошибки</returns>
int DecompressFile(ifstream &is, ofstream &os)
{
	int iPrefixCode[TBL_SIZE]{0};
	unsigned char cCharacter[TBL_SIZE];
	
	int iNumberOfCodes = InitializeStringTable(iPrefixCode, cCharacter);
	int iCurrentCode = GetNextCodeFromFile(is);
	if (OutputStringForCode(iPrefixCode, cCharacter, os, iCurrentCode)<0) {
		return -1;
	}

	int iOldCode = iCurrentCode;

	unsigned char cCurrentCharacter;
	while ((iCurrentCode = GetNextCodeFromFile(is)) >= 0){
		// Код переинициализации таблицы
		if (iCurrentCode == TBL_SIZE){
			iNumberOfCodes = InitializeStringTable(iPrefixCode, cCharacter);
			iCurrentCode = GetNextCodeFromFile(is);
			if (iCurrentCode<0) break;
			if (OutputStringForCode(iPrefixCode, cCharacter, os, iCurrentCode)<0) {
				return -1;
			}
			iOldCode = iCurrentCode;
		}
		else {
			// Если код уже есть в таблице, формируем для него последовательность
			if (iCurrentCode < iNumberOfCodes){
				if (OutputStringForCode(iPrefixCode, cCharacter, os, iCurrentCode)<0) {
					return -1;
				}
				// добавляем код для цепочки из первого байта цепочки текущего кода 
				// и предыдущего кода из входного потока в таблицу.
				// Это восстанавливает таблицу в порядке обратном формированию при компрессии 
				cCurrentCharacter = GetFirstCharacterForCode(iPrefixCode, cCharacter, iCurrentCode);
				iPrefixCode[iNumberOfCodes] = iOldCode;
				cCharacter[iNumberOfCodes] = cCurrentCharacter;
			}
			// Если кода нет, то сначала создаем его из предыдущего кода и его первого символа
			// Бывает и так.
			else {
				// добавляем код для цепочки из первого байта цепочки предыдущего кода 
				// и предыдущего кода из входного потока в таблицу.
				// Это восстанавливает таблицу в порядке обратном формированию при компрессии 
				cCurrentCharacter = GetFirstCharacterForCode(iPrefixCode, cCharacter, iOldCode);
				iPrefixCode[iNumberOfCodes] = iOldCode;
				cCharacter[iNumberOfCodes] = cCurrentCharacter;
				// а затем выводим цепочку для последнего добавленного кода.
				if (OutputStringForCode(iPrefixCode, cCharacter, os, iNumberOfCodes)<0) {
					return -1;
				}
			}
		
			iNumberOfCodes++;
			iOldCode = iCurrentCode;
		}
	}
	return 0;
}
