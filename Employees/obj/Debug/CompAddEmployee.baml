   M S B A M L   `   `   `  ����D  @Employees, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Employees	Employees  5          Employees.CompAddEmployee   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Employees     5        N� Title$  Employee - Add��5	      .��5      � $��
10,0,10,10q�6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      .+�5   
   ��    WatermarkImage#��[  6   $	��156��68   $��3��6E   $	��181��6V   $��1��6b   � 5   
   $��1��6   $��0,6,0,-6q�6    5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��Auto �6    .+�5*      �� $��0��6   $��0��6$   $��2��61     headerTextStyle#��[ 6E   $��Add Employee��6n   �� 5-      $��First Name:��6   $��0��6*   $��1��6:     
labelStyle#��[ 6G   �� 5.      -   5        $��FirstNameTextBox��5.      $��1��6.   $��1��6>     textBoxStyle#��[ 6K    �� 	MaxLength$ 15��5/   1   ��6   �� *	FirstName+61   �� 51      $��
Last Name:��6   $��0��6)   $��2��69   #��[ 6F   �� 52      -   5        $��LastNameTextBox��52      $��1��6-   $��2��6=   #��[ 6J   $ 15��53   0   ��6   �� *
LastName+60   �� 55      $��Role:��6   $��0��6$   $��3��64   #��[ 6A   �� 56      -   5        $��RoleComboBox��56      $��1��6+   $��3��6;     comboBoxStyle#��[ 6H    �� Text$ Select Role��57      ��6*   �� *EmpTypeNames+6O   �� 59      $
��DOB:��6   $��0��6#   $��4��63   #��[ 6@   �� 5:      -   5        $��
DOBDateBox��5:      $��1��6(   $��4��68   #��[ 6E     validationErrorTemplate =� ErrorTemplate# [ 5;      ��5<      �� *DOB+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ 	LostFocus=� �� ValidatesOnDataErrors . 	 �� StringFormat$	 d���� 5>      $
��SSN:��6   $��0��6#   $��5��63   #��[ 6@   �� 5?      -   5        $��
SSNTextBox��5?      $��1��6(   $��5��68   #��[ 6E   # [ 5@      ��5A      �� *SSN+$ TwoWay=�$ 	LostFocus=� . �� 5C      $
��Pay:��6   $��0��6#   $��6��63   #��[ 6@   �� 5D      -   5        $��PayBox��5D      $��1��6$   $��6��64   #��[ 6A   # [ 5E      ��5F      �� *Pay+$ TwoWay=�$ 	LostFocus=� . �� 5I      -   5        $��SpareProp1Name��5I      $��0��6*   $��7��6:   #��[ 6G   �� 5J      -   5        $��SpareProp1Value��5J      $��1��6-   $��7��6=   #��[ 6J   # [ 5K      ��5L      �� *Spare1Value+$ TwoWay=�$ 	LostFocus=� . �� 5M      -	   5        $��SpareProp1Combo��5M      $��1��6.   $��7��6>   #��[ 6K   �� 5O      -
   5        $��SpareProp2Name��5O      $�� ��6*   $��0��65   $��8��6E   #��[ 6R   �� 5P      -   5        $��SpareProp2Value��5P      $��1��6-   $��8��6=   #��[ 6J   # [ 5Q      ��5R      �� *Spare2Value+$ TwoWay=�$ 	LostFocus=� . �� 5S      -   5        $��SpareProp2Combo��5S      $��1��6.   $��8��6>   #��[ 6K   �� 5V      $
��Save��6   $��1��6$   $��9��64     buttonStyle#��[ 6A   $
��Auto��6f   $
��Save��6t   
 J� CommandBindings
 5W      )  #System.Windows.Input.CommandBinding  5X      -   5           Command$
 Save��5X   %   5Y   6   5[      5]      5^      5_      