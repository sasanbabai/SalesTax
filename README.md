# SalesTax
Calculates sales taxes based on specific criteria

## Input
Input 1: 
- 1 book at 12.49 
- 1 music CD at 14.99 
- 1 chocolate bar at 0.85 

Input 2:
- 1 imported box of chocolates at 10.00
- 1 imported bottle of perfume at 47.50

Input 3:
- 1 imported bottle of perfume at 27.99
- 1 bottle of perfume at 18.99
- 1 packet of headache pills at 9.75
- 1 box of imported chocolates at 11.25

## Requested output
Output 1:
- 1 book: 12.49
- 1 music CD: 16.49
- 1 chocolate bar: 0.85
- Sales Taxes: 1.50 Total: 29.83

Output 2:
- 1 imported box of chocolates: 10.50
- 1 imported bottle of perfume: ***54.65***
- Sales Taxes: ***7.65*** Total: ***65.15***

Output 3:
- 1 imported bottle of perfume: 32.19
- 1 bottle of perfume: 20.89
- 1 packet of headache pills: 9.75
- 1 imported box of chocolates: ***11.85***
- Sales Taxes: ***6.70*** Total: ***74.68***

## Calculated output
Output 1:
- 1 book: 12.49
- 1 music: 16.49
- 1 chocolate bar: 0.85
- Sales Taxes: 1.50 Total: 29.83

Output 2:
- 1 imported box of chocolates: 10.50
- 1 imported bottle of perfume: ***54.63***
- Sales Taxes: ***7.63*** Total: ***65.13***

Output 3:
- 1 imported bottle of perfume: 32.19
- 1 bottle of perfume: 20.89
- 1 packet of headache pills: 9.75
- 1 imported box of chocolates: ***11.81***
- Sales Taxes: ***6.66*** Total: ***74.64***

## Why the difference
Differences are marked as ***bold italic***. Either the values are miscalculated in the requirement or I didn't get the rule.

Following is the tax calculation for the second input (**1 imported bottle of perfume at 47.50**):
- Tax: 47.50 \* (0.15) = 7.125
- Rounding to the nearest 0.05 we will get 7.13
- Total item price = 47.50 + 7.13 = 54.63

Following is the tax calculation for the third input (**1 box of imported chocolates at 11.25**):
- Tax: 11.25 \* (0.5) = 0.5625
- Rounding to the nearest 0.05 we will get 0.56
- Total item price = 11.25 + 0.56 = 11.81
