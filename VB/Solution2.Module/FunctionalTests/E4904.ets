#Application Solution2.Win
*Action New
*CheckFieldValues
 Code = ''
*Action Close
*HandleDialog
 Respond = No
*Action New
*Action Save
*CheckFieldValues
 Code = N000001
*FillForm
 Name = changed
*Action Save
*CheckFieldValues
 Code = N000001
*Action Save and New
*Action Save and Close
*CheckTable
 Columns = Code
 Row = N000001
 Row = N000002

