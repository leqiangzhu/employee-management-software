   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      D @Employees, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Employees	Employees 5         Employees.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      7core&clr-namespace:System;assembly=mscorlib     5      )localclr-namespace:Employees     5        �� 	Resources  5         WatermarkImage �� 
TargetType �� Property �� Value  headerTextStyle  
labelStyle  textBoxStyle  dollarBoxStyle  comboBoxStyle  buttonStyle  HorizontalRadio d� 	IsChecked �� Path �� RelativeSource �� Mode  HorizontalRadioList �� 
TargetType-  'System.Windows.Input.KeyboardNavigation	   TabNavigation
 K� IsItemsHost �� Orientation 	 	RightCell 
 RightCellEdit  RightHeader=  7System.Windows.Controls.Primitives.DataGridColumnHeader  CellEditStyle �� Triggers P� Property P� Value  ExpenseCategory S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� Type  Employees.ExpenseCategory  validationErrorTemplate �� TextAlignment � ToolTip �� ElementName ��Name��%d  &	        &	 �     &	 �    &	 �    &	 �    &	 g    &	 I    &	     &	 "    &		 $    &	
 o    &	 �    &	 	    &	 �	    &	 ,
    �� 5	   
   " ��6'   .�5
      ��  � ��$ watermark.png��6'   �� 5       � ��$
 left=�64   �� 5       � ��$	 top=�62   �� 5       � ��$	 230��6&   �� 5       �@J�Opacity$	 0.5Q�6(   5      �� 5   
   .�5      ��  � ��$ Center=�68   6I   �� 5       � ��$ Trebuchet MS)�61   6H   �� 5       � ��$
 Bold"�61   6@   �� 5       � ��$ 18(�6/   6<   �� 5       � �� �#0066cc6C   5      �� 5   
   " ��6#   .�5      ��  � ��$	 Top=�62   �� 5       � ��$
 Left=�64   �� 5       � ��$ Medium"�6+   �� 5       � ��$ 0q�6'   5       �� 5#   
   " ��6%   .�5$      ��  � ��$ Center=�62   �� 5%       � ��$
 Left=�64   �� 5&       � ��$ Medium"�6+   �� 5'       � ��$ 0q�6'   �� 5(       � ��$	 120��6&   5)      �� 5,   
   " ��6'   .�5-      ��  � ��$ Center=�62   �� 5.       � ��$ Right=�64   �� 5/       � ��$ Medium"�6+   �� 50       � ��$ 0q�6'   �� 51       � ��$	 120��6&   52      �� 55   
   " ��6&   .�56      ��  � ��$ Center=�62   �� 57       � ��$
 Left=�64   �� 58       � ��$ Medium"�6+   �� 59       � ��$ 0q�6'   �� 5:       � ��$	 120��6&   5;      �� 5>   
   " ��6$   .�5?      ��  � ��$	 125��6&   �� 5@       � ��$ 25��6'   �� 5A       � ��$ 0,10,0,0q�6'   �� 5B       � ��$ Right=�64   5C      �� 5F   
   " ��6(   .�5G      ��  � ��$ 0,5,5,0q�6'   �� 5H       � �� 5I      �� 5J      .R�5K      	� |�.  #��z��5L      $��Center=�5M       5N      �� $ 
IsSelected� �� *TemplatedParent+$ TwoWay=�5O      5Q      5R      �� 5U   
   " ��6,   .�5V      ��  � �� .  6*   �� 5W       � ��$ 0q�6'   �� 5X       � �� 5Y      �� 5Z      " ��6&   .R�5[      �� $
	 Once=�6%   
 . $ 
Horizontal=�6`   $��25��6y   5\      5^      5_      �� 5c   
   " ��6   .�5d      ��  � ��$ Right=�64   5e      �� 5h   
   " ��6   .�5i      ��  � ��$ Right=�64   5j      �� 5m   
   "  6$   .�5n      ��  � ��$ Right=�6;   5o      �� 5r   
   " ��6&    5s      P� 5t       �@=�HasError . . �5u      ��  �@�ToolTip 5v      ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�5x      5z      S� 5}   
   $ 	GetValues��65   "  6L    5~      M� 5      "  6   5�      �� 5�   
   .R�5�      ]� .+�5�      �� $ 
Horizontal=�6   $��Right=�66   .+�5�      � $��12��6   $��12��6&   .+�5�      A� $��12��6"   $��12��6-   
���  ��$��Center=�6D   $��Center=�6a   �� 5�      
�������$��Heavy"�67   $��8(�6J   $��Center=�6W   $��Center=�6t   $ Center=�6�    5�       �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�X5�      5�      �� 5�      
���  ��$��Light"�61   $��2,0,0,0q�6D   ��5�      �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5�      �� 5�      $ ErrorAdorner��6,   6E   5�      5�      5�      5�      