#pragma once
#include <iostream>	// Нужно, т.к. есть методы визуализации
#include <map>		// для хранения ребер ведущих к дочерним узлам
#include "Edge.h"
#include "Node.h"
using namespace std;

/// <summary>
/// For Ukkonen algorithm
/// Represents Active Point (state machine)
/// </summary>
class ActivePoint {
public:
	Node* node;		// Текущий активный узел
	int edge = -1;	// Текущее активное ребро в активном узле
	int length;		// Длина по активному ребру
};

class SufTree {
	const char* input;				// Буфер где заполняется T
	int last_read = -1;				// Количество прочитанных байтов
	Node* lastCreatedNode = nullptr;

	int node_count = 0;					// Счетчик для задания id-узла.
	Node* root = new Node(node_count++);

	int remainder = 0;					// Количестов суффиксов еще не добавленных явно, но уже присутствующих в дереве.
	ActivePoint ap = { root, -1, 0 };	// {текущий узел, активное ребро в узле, длина по активному ребру}
public:

	SufTree(const char* inp) :input(inp){}
	SufTree(const SufTree&) = delete;			// Запретили копирование, чтобы пользовались ссылками
	SufTree& operator=(const SufTree&) = delete;// Запретили присванивание.

	// все для деструктора
	void deleteEdge(Edge& e) {
		if (e.node)
			deleteNode(e.node);
	}

	void deleteNode(Node* n) {
		for (auto& c : n->children)
		{
			deleteEdge(c.second);
		}
		delete n;
	}
	~SufTree() {
		deleteNode(root);
	}
	// Методы построения дерева
	void extend(int i);
	void finalize();
	
	// Лучше здесь, т.к. нужен индекс последнего прочитаннного смивола. 
	int edgeLen(Edge& e) {
		return e.end >= 0 ? e.end - e.start + 1 : last_read - e.start + 1;
	}
#pragma region Прикладные методы
private:
	/// <summary>
	/// Заполняет поле sufIdx листовых ребер индексом суффикса во входном потоке
	/// </summary>
	/// <param name="n">указатель на узел</param>
	/// <param name="len">длина ребер от корня до узла</param>
	void fillLeaves(Node* n, int len)
	{
		for (auto& p : n->children)
		{
			int _len = len + edgeLen(p.second);
			if (p.second.isLeaf()) {
				p.second.sufIdx = last_read - _len + 1;
			}
			if (p.second.node)
				fillLeaves(p.second.node, _len);
		}
	}
public:
	void FillLeaves() {
		fillLeaves(root, 0);
	}
#pragma endregion
private:
	// методы визуализации
	/// <summary>
	/// Виузализирует актвиную точку (часть состояния автомата)
	/// </summary>
	void showActivePoint() {
		if (ap.edge >= 0)
			cout << '(' << ap.node->id << ", " << input[ap.edge] << ", " << ap.length << ')';
		else
			cout << '(' << ap.node->id << ", " << "undef, " << ap.length << ')';
	}
	/// <summary>
	/// Визуализирует ребро
	/// </summary>
	/// <param name="e">Ссылка на ребро</param>
	/// <param name="level">Уровень ребра в дереве</param>
	void showEdge(Edge& e, int level)
	{
		for (int i = 0; i < edgeLen(e); i++)
			cout << input[e.start + i];
		if(e.isLeaf())
			cout << '|' << e.sufIdx;	// Значит ребро представлет собой и лист
		cout << endl;
	}
	/// <summary>
	/// Визуализация узла
	/// </summary>
	/// <param name="n">указатель на узел</param>
	/// <param name="level">уровень узла в дереве</param>
	void showNode(Node* n, int level) {
		string shift(level, '\t');
		cout << shift << n->id;
		if (n->suffix_link)
			cout << " --> " << n->suffix_link->id;
		cout << endl;
		for (auto e : n->children) {
			cout <<shift << "    ";
			showEdge(e.second, level);
			if (e.second.node != nullptr)
				showNode(e.second.node, level+1);
		}
	}

public: 
	void ShowTree()
	{
		showNode(root, 0);
	}

};
