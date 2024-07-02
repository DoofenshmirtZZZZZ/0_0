#include <iostream>
#include <string.h>
class _str
{
	char* m_pszData;
	int m_nCount;

	friend class Str;
	_str() {
		m_pszData = new char[1] { 0 }; m_nCount = 1;
	}

	_str(const char* p) {
		m_nCount = 1;
		m_pszData = new char[strlen(p) + 1];
		strcpy_s(m_pszData, strlen(p) + 1, p);
	}

	~_str() { delete[]m_pszData; }

	void AddRef() { m_nCount++; }
	void Release() { m_nCount--; if (m_nCount == 0) delete this; }

	void reverse() {
		std::cout << "string = " << m_pszData << std::endl;

		int len = strlen(m_pszData);
		bool break_flag = true;
		for (int i = 0; i < len; i++)
			if (m_pszData[i] != m_pszData[len - i - 1])
				break_flag = false;

		if (break_flag == true) {
			std::cout << "string is palindrome" << std::endl;
			return;
		}

		char* data = _strdup(m_pszData);

		for (int i = 0; i < len; i++)
			data[i] = m_pszData[len - i - 1];

		m_pszData = data;
		std::cout << "reversed string = " << m_pszData << std::endl;
	}
};


