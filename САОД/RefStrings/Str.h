#pragma once
#include "_str.h"
class Str : public _str
{
	_str* m_pStr;
public:
	// вариант 3 
	// который ищет последнее вхождение подстроки t в исходную строку, до смещени€ off. 
	// “.е. найденное совпадение не может начинатьс€ после off. 
	// ≈сли вхождени€ нет, то метод возвращает -1, если есть, то индекс последнего вхождени€ до off от начала исходной строки. 

	int rfind(const char* t, int off) const 
	{
		int n = strlen(m_pStr->m_pszData);
		int m = strlen(t);
		int j = 0;
		off = (n - m > off) ? off : n - m;
		for (int i = off; i >= 0; i--) // идем от конца
		{
			for (j = 0; j < m; j++)
				if (m_pStr->m_pszData[i + j] != t[j]) // 
					break;
			if (j == m) 
				return i; 
		}
		return -1; //≈сли дошли до начала исходной строки, а совпадени€ нет, значит совпадение не найдено и метод возвращает -1. 
	}


	Str() { m_pStr = new _str; }		//если не копи€, то создаем
	Str(const char* p) {		// новый ресурс
		m_pStr = new _str(p);
	}
	~Str() {
		m_pStr->Release(); 	// Ќе уничтожаем ресурс!
	}				// ”меньшаем счетчик ссылок!

	int len() const {
		return strlen(m_pStr->m_pszData);
	}


	Str(const Str& s)
	{
		m_pStr = s.m_pStr; 	// ссылаемс€ на тот же ресурс
		m_pStr->AddRef(); 	// отмечаем, что сослались
	}


	Str& operator = (const Str& s) {
		if (this != &s) {
			s.m_pStr->AddRef(); // ¬ажен пор€док?!
			m_pStr->Release();
			m_pStr = s.m_pStr;
		}
		return *this;
	}


	Str& operator += (const Str& s) {
		int length = len() + s.len();
		if (s.len() != 0) {			// добавление ничего не изменит!
			_str* pstrTmp = new _str; 	// Ќовый ресурс
			delete[] pstrTmp->m_pszData;

			pstrTmp->m_pszData = new char[length + 1];
			strcpy_s(pstrTmp->m_pszData, length + 1, m_pStr->m_pszData);
			strcat_s(pstrTmp->m_pszData, length + 1, s.m_pStr->m_pszData);

			m_pStr->Release();
			m_pStr = pstrTmp;
		}
		return *this;
	}



	operator const char* ()const { return m_pStr->m_pszData; }
};
