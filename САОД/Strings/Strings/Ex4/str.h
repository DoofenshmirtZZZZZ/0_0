#pragma once
#include <string>
class Str {
	char* m_pszText;
public:

	Str() 	//Конструктор “по умолчанию” (default)*
	{
		m_pszText = new char[1]{ 0 };
	}

	~Str() { delete[]m_pszText; }

	Str(const char* p)
	{
		if (p) {
			m_pszText = new char[strlen(p) + 1];
			strcpy_s(m_pszText, strlen(p) + 1, p);
		}
		else
			m_pszText = new char[1]{ 0 };
	}

	operator const char* ()const { return m_pszText; }

	Str(const Str& s) //Константная ссылка на объект
	{
		m_pszText = new char[strlen(s.m_pszText) + 1];
		strcpy_s(m_pszText,
			strlen(s.m_pszText) + 1,
			s.m_pszText);
	}

	const Str& operator = (const Str& s) //Константная ссылка на объект
	{
		if (&s == this) return *this;
		delete[] m_pszText;	 //Освобождаем текущие данные					//Дальше просто копирование
		m_pszText = new char[strlen(s.m_pszText) + 1];
		strcpy_s(m_pszText, strlen(s.m_pszText) + 1, s.m_pszText);
		return *this;
	}

	Str& operator +=(const char* sz)
	{
		char* temp = new char[strlen(m_pszText) + 1];
		strcpy_s(temp, strlen(m_pszText) + 1, m_pszText);
		delete[] m_pszText;
		m_pszText = new char[2 + strlen(sz) + strlen(temp)];
		strcpy_s(m_pszText, strlen(temp) + 1, temp);
		strcat_s(m_pszText, strlen(temp) + strlen(sz) + 1, sz);
		delete[] temp;
		return *this;
	}

	Str operator +(const char* sz) const
	{
		Str s1(m_pszText);
		s1 += sz;
		return s1;
	}
};
