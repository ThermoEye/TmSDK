#pragma once

#include <string>
#include <vector>
#include <sstream>
#include <iomanip>

using namespace std;

string trim(string& str, const string& drop = " \t\r\n\v");
string rtrim(string str, const string& drop = " \t\r\n\v");
string ltrim(string str, const string& drop = " \t\r\n\v");
std::vector<string> split(string& str, string sep);
std::vector<string> split_first_of(string& str, string sep);
string ReplaceAll(const string& src_str, const string& find_str, const string& replace_str);
string replaceAll(const string& src_str, const string& find_str, const string& replace_str);
