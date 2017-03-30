#include "stdafx.h"
#include <vector>
#include <iostream>
#include <fstream>
#include <string>
#include <sstream>

using namespace std;

const char NULL_CH = '.';

void ReadVectorFromFile(const string &line, vector<char> &vect);
vector<int> MoveArray(vector<char> &vect);

void WriteVectorOfNums(const vector<int> &vect);
void WriteVectorOfChars(const vector<char> &vect);

int main(int argc, char *argv[])
{
	(void)argc;
	(void)argv;

	vector<char> line;
	vector<int> map;

	ReadVectorFromFile(argv[1], line);

	map = MoveArray(line);

	WriteVectorOfChars(line);
	WriteVectorOfNums(map);

	return 0;
}

vector<int> MoveArray(vector<char> &vect)
{
	vector<int> moveMap;

	for (auto ch : vect)
	{
		moveMap.push_back(0);
	}

	for (size_t i = 1; i < vect.size(); i++)
	{
		int currPlate = vect[i];
		if (currPlate == NULL_CH)
		{
			continue;
		}

		vect[i] = NULL_CH;
		int currPosition = i;
		int moveCount = 0;

		while (currPosition > 0 && vect[currPosition - 1] == NULL_CH)
		{
			currPosition--;
			moveCount++;
		}

		moveMap[i] = moveCount;
		vect[currPosition] = currPlate;
	}

	return moveMap;
}

void ReadVectorFromFile(const string &line, vector<char> &vect)
{
	for (auto& ch : line)
	{
		vect.push_back(ch);
	}
}

void WriteVectorOfChars(const vector<char> &vect)
{
	for (auto& num : vect)
	{
		cout << num << " ";
	}

	cout << "\n";
}

void WriteVectorOfNums(const vector<int> &vect)
{
	for (auto& num : vect)
	{
		cout << num << " ";
	}

	cout << "\n";
}