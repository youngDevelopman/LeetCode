// GenerateParentheses.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <string>

using namespace std;
using std::vector;
using std::string;

class Solution {
public:
    vector<string> generateParenthesis(int n) {
        vector<string> result;
        generateParenthesis(result, "", 0, 0, n);
        return result;
    }
private:
    void generateParenthesis(vector<string>& result, string s, int open, int closed, int n) {
        if (open == n && closed == n) 
        {
            result.push_back(s);
            return;
        }

        if (open < n) 
        {
            generateParenthesis(result, s + '(', open + 1, closed, n);
        }

        if (closed < open)
        {
            generateParenthesis(result, s + ')', open, closed + 1, n);
        }
    }
};
int main()
{
    Solution myObj;
    vector<string> res = myObj.generateParenthesis(3);
    std::cout << "Number of elements " << res.size() << endl;
    for (size_t i = 0; i < res.size(); i++)
    {
        std::cout << res[i] << endl;
    }
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
