#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <ctime>

using namespace std;

const int ARGUMENTS_COUNT = 0;

const size_t MIN_SIZE = 2;
const size_t MAX_SIZE = SIZE_MAX;

bool IsArgumentsValid(string const& sizeStr, int& matrixSize);
bool String2Int(string const& str, int& result);
vector<vector<char>> GetRandomMatrix(size_t size);
vector<size_t> GetRandomVector(size_t size);
void PrintMatrixToFile(ofstream& file, vector<vector<char>> const& matrix);

int main(int argc, char* argv[])
{
	(void)argc;
	(void)argv;

	string sizeStr;
	int matrixSize;
	string fileName;

	cout << "Hello friend! Let I help you with create matrix.\n"
		<< "The size of the matrix can be in the range [" << MIN_SIZE << ", " << MAX_SIZE << "].\n";

	cout << "Matrix size: ";
	cin >> sizeStr;

	cout << "Output file name: ";
	cin >> fileName;

	if (!IsArgumentsValid(sizeStr, matrixSize))
	{
		cout << "Invalid arguments!\n"
			<< "The size of the matrix can be in the range [" << MIN_SIZE << ", " << MAX_SIZE << "].\n";

		return 1;
	}

	ofstream output(fileName);

	vector<vector<char>> matrix = GetRandomMatrix(matrixSize);
	PrintMatrixToFile(output, matrix);

	return 0;
}

bool IsArgumentsValid(string const& sizeStr, int& matrixSize)
{
	if (String2Int(sizeStr, matrixSize))
	{
		if (matrixSize >= MIN_SIZE && matrixSize <= MAX_SIZE)
		{
			return true;
		}
	}

	return false;
}

vector<vector<char>> GetRandomMatrix(size_t size)
{
	vector<vector<char>> matrix;
	vector<size_t> randomVector = GetRandomVector(size);

	for (size_t i = 0; i < size; i++)
	{
		vector<char> line;
		matrix.push_back(line);
		size_t randomTransfer = randomVector[i];

		for (size_t j = 0; j < size; j++)
		{
			if (randomTransfer == j)
			{
				matrix[i].push_back('1');
			}
			else
			{
				matrix[i].push_back('0');
			}
		}
	}

	return matrix;
}

vector<size_t> GetRandomVector(size_t intervalMax)
{
	vector<size_t> intervalVector;
	vector<size_t> randomVector;
	srand(static_cast<unsigned>(time(0)));

	for (size_t i = 0; i < intervalMax; i++)
	{
		intervalVector.push_back(i);
	}

	while (!intervalVector.empty())
	{
		int randomPos = rand() % intervalVector.size();
		int randomValueFromInterval = intervalVector[randomPos];
		randomVector.push_back(randomValueFromInterval);
		intervalVector.erase(intervalVector.begin() + randomPos);
	}

	return randomVector;
}

void PrintMatrixToFile(ofstream& file, vector<vector<char>> const& matrix)
{
	for (size_t i = 0; i < matrix.size(); i++)
	{
		for (size_t j = 0; j < matrix[0].size(); j++)
		{
			file << matrix[i][j] << " ";
		}
		file << "\n";
	}
}

bool String2Int(string const& str, int& result)
{
	try
	{
		size_t lastChar;
		result = stoi(str, &lastChar, 10);
		return lastChar == str.size();
	}
	catch (invalid_argument&)
	{
		return false;
	}
	catch (out_of_range&)
	{
		return false;
	}
}