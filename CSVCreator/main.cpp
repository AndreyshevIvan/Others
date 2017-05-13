#include <fstream>
#include <string>
#include <vector>
#include <iostream>
#include <exception>
#include <ctime>

namespace
{
	const char SEPARATOR = ';';
	const int MIN_ARGS = 3;
}

void EnterProcess(size_t recordsCount, const std::vector<std::string> &dictionariesFiles);
std::string GetRandomWord(const std::vector<std::string> &dictionary);
std::vector<std::string> GetAllRowsFromFile(const std::string &fileName);

int main(int argc, char* argv[])
{
;	if (argc < MIN_ARGS)
	{
		std::cout << "Invalid arguments count" << std::endl;
		return 1;
	}

	try
	{
		if (std::stoi(std::string(argv[1])) <= 0)
		{
			throw std::exception("Invalid records count.");
		}

		size_t recordsCount = (size_t)std::stoi(std::string(argv[1]));
		std::vector<std::string> dictionariesFiles;

		for (int i = 2; i < argc; i++)
		{
			std::string file(argv[i]);
			dictionariesFiles.push_back(file);
		}

		EnterProcess(recordsCount, dictionariesFiles);
	}
	catch (const std::exception &e)
	{
		std::cout << e.what();
		return 1;
	}

	return 0;
}

void EnterProcess(size_t recordsCount, const std::vector<std::string> &dictionariesFiles)
{
	srand((unsigned)time(0));
	std::vector<std::vector<std::string>> fullDictionary;
	std::ofstream output("output.csv");

	for (auto &fileName : dictionariesFiles)
	{
		fullDictionary.push_back(GetAllRowsFromFile(fileName));
	}

	for (size_t recNum = 0; recNum < recordsCount; recNum++)
	{
		for (auto &dictionary : fullDictionary)
		{
			auto record = GetRandomWord(dictionary);
			output << record;
			if (dictionary != fullDictionary.back())
			{
				output << SEPARATOR;
			}
		}
		output << std::endl;
	}
}

std::vector<std::string> GetAllRowsFromFile(const std::string &fileName)
{
	std::vector<std::string> rows;
	std::ifstream file(fileName);

	if (!file.is_open())
	{
		throw std::exception("Words file not open.");
	}

	std::string word;

	while (getline(file, word))
	{
		if (word == "")
		{
			throw std::exception("Dictionary word can not be empty.");
		}
		rows.push_back(word);
	}

	return rows;
}

std::string GetRandomWord(const std::vector<std::string> &dictionary)
{
	if (dictionary.empty())
	{
		throw std::exception("Take random string from empty dictionary.");
	}

	int randomIndex = rand() % (dictionary.size() - 1);

	return dictionary[(size_t)randomIndex];
}
