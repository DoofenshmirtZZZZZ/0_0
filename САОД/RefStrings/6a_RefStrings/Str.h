#pragma once
#include "_str.h"
class Str : public _str
{
	_str* m_pStr;
public:
	// ������� 3 
	// ������� ���� ��������� ��������� ��������� t � �������� ������, �� �������� off. 
	// �.�. ��������� ���������� �� ����� ���������� ����� off. 
	// ���� ��������� ���, �� ����� ���������� -1, ���� ����, �� ������ ���������� ��������� �� off �� ������ �������� ������. 

	int rfind(const char* t, int off) const 
	{
		int n = strlen(m_pStr->m_pszData);
		int m = strlen(t);
		int j = 0;
		off = (n - m > off) ? off : n - m;
		for (int i = off; i >= 0; i--) // ���� �� �����
		{
			for (j = 0; j < m; j++)
				if (m_pStr->m_pszData[i + j] != t[j]) // 
					break;
			if (j == m) 
				return i; 
		}
		return -1; //���� ����� �� ������ �������� ������, � ���������� ���, ������ ���������� �� ������� � ����� ���������� -1. 
	}


	Str() { m_pStr = new _str; }		//���� �� �����, �� �������
	Str(const char* p) {		// ����� ������
		m_pStr = new _str(p);
	}
	~Str() {
		m_pStr->Release(); 	// �� ���������� ������!
	}				// ��������� ������� ������!

	int len() const {
		return strlen(m_pStr->m_pszData);
	}


	Str(const Str& s)
	{
		m_pStr = s.m_pStr; 	// ��������� �� ��� �� ������
		m_pStr->AddRef(); 	// ��������, ��� ���������
	}


	Str& operator = (const Str& s) {
		if (this != &s) {
			s.m_pStr->AddRef(); // ����� �������?!
			m_pStr->Release();
			m_pStr = s.m_pStr;
		}
		return *this;
	}


	Str& operator += (const Str& s) {
		int length = len() + s.len();
		if (s.len() != 0) {			// ���������� ������ �� �������!
			_str* pstrTmp = new _str; 	// ����� ������
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
