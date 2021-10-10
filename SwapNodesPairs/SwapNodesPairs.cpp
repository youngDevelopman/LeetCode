// SwapNodesPairs.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

 struct ListNode {
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode *next) : val(x), next(next) {}
 };
 

class Solution {
public:
    ListNode* swapPairs(ListNode* head) {

        if (head == nullptr) return head;

        ListNode* curr = head;
        ListNode* prev = nullptr;
        ListNode* next = nullptr;

        while (curr != nullptr && curr->next != nullptr)
        {
            next = curr->next;

            ListNode* temp = curr->next->next;

            if (prev != nullptr)
            {
                prev->next = curr->next;
            }
            else
            {
                head = next;
            }

            curr->next = temp;
            next->next = curr;

            prev = curr;
            curr = temp;
        }


        return head;
    }
};

int main()
{
    ListNode* head = new ListNode(1);
    head->next = new ListNode(2);
    head->next->next = new ListNode(3);
    head->next->next->next = new ListNode(4);
    
    Solution solution;
    solution.swapPairs(head);
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
