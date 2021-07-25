// LetterCombinations.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <vector>
#include <unordered_map>

using namespace std;
using std::vector;
using std::unordered_map;
using std::string;

#define _HAS_ITERATOR_DEBUGGING 0
#define _SECURE_SCL 0

class Solution {
private:
    unordered_map<int, vector<string>> letterMappings = 
    { 
        {2, {"a", "b", "c"}},
        {3, {"d", "e", "f"}},
        {4, {"g", "h", "i"}},
        {5, {"j", "k", "l"}},
        {6, {"m", "n", "o"}},
        {7, {"p", "k", "r", "s"}},
        {7, {"p", "k", "r", "s"}},
        {8, {"t", "u", "v"}},
        {9, {"w", "x", "y", "z"}},
    };
public:
    vector<string> letterCombinations(string digits) {
        vector<string> result;

        if (!digits.empty()) {
            result = letterMappings[(int)digits[0] - 48];
        }

        for (size_t i = 1; i < digits.size(); i++)
        {
            vector<string> mapping = letterMappings[(int)digits[i] - 48];
            vector<string> temp;
            for (size_t i = 0; i < result.size(); i++)
            {
                for (size_t j = 0; j < mapping.size(); j++)
                {
                    temp.push_back(result[i] + mapping[j]);
                }
            }
            result = temp;
        }

        return result;
    }
};

// Recursive
class Solution2 {
private:
    vector<string> keys = { "","","abc","def","ghi","jkl","mno","pqrs","tuv","wxyz" };
    void bt(vector<string>& res, string temp, int start, string digits) {
        
        if (digits.size() == temp.size()) {
            res.push_back(temp);
            return;
        }

        string s = keys[digits[start] - '0'];
        for (size_t i = 0; i < s.size(); i++)
        {
            temp += s[i];
            bt(res, temp, start + 1, digits);
            temp.pop_back();
        }
    }
public:
    vector<string> letterCombinations(string digits) {
        vector<string> res;
        if (digits.size() == 0)
            return res;
        bt(res, "", 0, digits);

        return res;
    }
};

int main()
{
    Solution2 myObj;
    vector<string> res = myObj.letterCombinations("234");
    std::cout << "Number of elements " << res.size() << endl;
    for (size_t i = 0; i < res.size(); i++)
    {
        std::cout << res[i] << endl;
    }
}
