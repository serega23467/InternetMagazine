   M S B A M L   `   `   `  ����K  GInternetMagazine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:InternetMagazineInternetMagazine  5   	   $    InternetMagazine.WindowManager   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:InternetMagazine     5   	   $	��700��5   	   $
��1273��6     � WindowStartupLocation$  CenterScreen=�6#   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $	��90* �6   .+�5   
   �� -   5         ��Name$ 
tabControl��5      $��1��6)    �� SelectedIndex$ 0��66   $��20(�6H   .@�5      �� $��Users��6   .��5      � ���	#FFE5E5E5 � ColumnDefinitions 5      �� 5      $	��70* �6+   �� 5      $	��30* �6+   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridUsers��5         AutoGenerateColumns$ False��6a      
IsReadOnly$
 True��6}   $��16(�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��61   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6=   �� *Id+  5      $	 Login��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6^   
 6@   �� *	UserLogin+6^     5      $
	 Role��61   $
 Auto 6`   
 6?   �� *StatusString+6`     5      $
	 Name��61   $
 Auto 6\   
 6?   �� *
UserName+6\     5      $	 Phone number��61   $ * 6g   
 6G   �� *PhoneNumber+6g   5      �� 5      -   5         ��Name$ buttonUpdateUsers��5      $��1��68   $��Update list��6H   $
��Left=�6^   $��
234,10,0,0q�6y   $	��Top=�6�   $	��114��6�   $��20(�6�   6�   �� 5      $��1��6    $
��Left=�60   $��	11,58,0,0q�6K   $
��Wrap=�6^   $��Id��6r   $	��Top=�6|   $��20(�6�   �� 5       $��1��6    $
��Left=�60   $��	11,90,0,0q�6K   $
��Wrap=�6^   $��Login��6r   $	��Top=�6   $��20(�6�   �� 5!      $��1��6    $
��Left=�60   $��
11,130,0,0q�6K   $
��Wrap=�6_   $
��Name��6s   $	��Top=�6   $��20(�6�   �� 5"      $��1��6    $
��Left=�60   $��
11,166,0,0q�6K   $
��Wrap=�6_   $
��Role��6s   $	��Top=�6   $��20(�6�   �� 5#      $��1��6    $
��Left=�60   $��
11,209,0,0q�6K   $
��Wrap=�6_   $��Phone��6s   $	��Top=�6�   $��20(�6�   �� 5$      $��1��6    $
��Left=�60   $��
11,259,0,0q�6K   $
��Wrap=�6_   $��Password��6s   $	��Top=�6�   $��20(�6�   $	��103��6�   �� 5&      -   5         ��Name$ textBlockUserId��5&       $��1��69   $
��Left=�6I   $��
147,57,0,0q�6d   $
��Wrap=�6x   $�� ��6�   $	��Top=�6�   $��20(�6�   �� 5'      -   5         ��Name$ textBoxEditLogin��5'      $��1��68   $
��Left=�6H   $��
146,89,0,0q�6c    �� TextWrapping$
 Wrap=�6w   $	��Top=�6�   $	��204��6�   $��20(�6�    �� 	MaxLength$ 20��6�   �� 5(      -   5        $ textBoxEditName��5(      $��1��67   $
��Left=�6G   $��145,129,0,0q�6b   $
 Wrap=�6w   $	��Top=�6�   $	��203��6�   $��20(�6�   $ 20��6�   �� 5)      -   5         ��Name$ comboBoxEditStatus��5)      $��1��6;   $
��Left=�6K   $��147,166,0,0q�6f   $	��Top=�6{   $	��202��6�   $��32��6�   $��20(�6�   �� 5*      -   5        $ textBoxEditPhone��5*      $��1��68   $
��Left=�6H   $��145,207,0,0q�6c   $
 Wrap=�6x   $	��Top=�6�   $	��203��6�   $��20(�6�   $��29��6�   $ 12��6�   �� 5+      -	   5        $ textBoxUserPass��5+      $��1��67   $
��Left=�6G   $��145,259,0,0q�6b   $	��Top=�6w   $	��203��6�   $��20(�6�   $ 20��6�   5,      5-      �� 5.      $��
Categories��6   .��5/      � ���	#FFE5E5E5 50      �� 51      $	��70* �6+   �� 52      $	��30* �6+   .+�54        -
   5        $ dataGridCategories��54      $ False��6f   $
 True��6�   $��16(�6�    55        56      $	 ID��61   
 6=   �� *Id+  57      $	 Category��61   $ * 6d   
 6C   �� *CategoryName+6d   59      �� 5:      -   5        $ buttonUpdateCategories��5:      $��1��6=   $��Update list��6M   $
��Left=�6c   $��
234,10,0,0q�6~   $	��Top=�6�   $	��114��6�   $��20(�6�   6�   �� 5;      $��1��6    $
��Left=�60   $��	13,71,0,0q�6K   $
��Wrap=�6^   $��Id��6r   $	��Top=�6|   $��20(�6�   �� 5<      $��1��6    $
��Left=�60   $��
13,111,0,0q�6K   $
��Wrap=�6_   $��Category��6s   $	��Top=�6�   $��20(�6�   �� 5>      -   5        $ textBlockCategoryId��5>       $��1��6>   $
��Left=�6N   $��
149,70,0,0q�6i   $
��Wrap=�6}   $�� ��6�   $	��Top=�6�   $��20(�6�   �� 5?      -   5        $ textBoxCategoryName��5?      $��1��6;   $
��Left=�6K   $��148,110,0,0q�6f   $
 Wrap=�6{   $	��Top=�6�   $	��204��6�   $��20(�6�   $ 20��6�   5@      5A      �� 5B      $��Products��6   .��5C      � ���	#FFE5E5E5 5D      �� 5E      $	��70* �6+   �� 5F      $	��30* �6+   .+�5H        -   5        $ dataGridProducts��5H      $ False��6d   $
 True��6�   $��16(�6�    5I      4  .System.Windows.Controls.DataGridTemplateColumn  5J         CellTemplate 5K   "   �� 5L   &   .R�5M   *   �� $��50��6O   $��50��6Z   $
��Fill=�6f   ��60   �� *ImageBitmap+6f   5N   '   5P        5Q      $	 ID��61   
 6=   �� *Id+  5R      $	 Category��61   $
 Auto 6`   
 6C   �� *
Category+6`     5S      $
	 Name��61   $
 Auto 6_   
 6?   �� *ProductName+6_     5T      $	 Price��61   $
 Auto 6a   
 6@   �� *ProductPrice+6a     5U      $	 Has in garbage��61   $
 Auto 6p   
 6I   �� *HasInGarbageString+6p     5V      $	 Description��61   $ * 6m   
 6F   �� *ProductDescription+6m   5X      �� 5Y      -   5        $ buttonUpdateProducts��5Y      $��1��6;   $��Update list��6K   $
��Left=�6a   $��
234,10,0,0q�6|   $	��Top=�6�   $	��114��6�   $��20(�6�   6�   �� 5Z      $��1��6    $
��Left=�60   $��	11,58,0,0q�6K   $
��Wrap=�6^   $��Id��6r   $	��Top=�6|   $��20(�6�   �� 5[      $��1��6    $
��Left=�60   $��	11,90,0,0q�6K   $
��Wrap=�6^   $
��Name��6r   $	��Top=�6~   $��20(�6�   �� 5\      $��1��6    $
��Left=�60   $��
11,130,0,0q�6K   $
��Wrap=�6_   $��Description��6s   $	��Top=�6�   $��20(�6�   �� 5]      $��1��6    $
��Left=�60   $��
11,196,0,0q�6K   $
��Wrap=�6_   $	��Top=�6s   $��20(�6�   $��Category��6�   �� 5^      $��1��6    $
��Left=�60   $��
12,329,0,0q�6K   $
��Wrap=�6_   $��Price��6s   $	��Top=�6�   $��20(�6�   �� 5_      $��1��6    $
��Left=�60   $��
12,256,0,0q�6K   $
��Wrap=�6_   $��Has in garbage��6s   $	��Top=�6�   $��20(�6�   $	��103��6�   �� 5a      -   5        $ textBlockProductId��5a       $��1��6<   $
��Left=�6L   $��
147,57,0,0q�6g   $
��Wrap=�6{   $�� ��6�   $	��Top=�6�   $��20(�6�   �� 5b      -   5        $ textBoxEditProductName��5b      $��1��6>   $
��Left=�6N   $��
147,88,0,0q�6i   $
 Wrap=�6}   $	��Top=�6�   $	��201��6�   $��20(�6�   $ 20��6�   �� 5c      -   5        $# textBoxEditProductDescription��5c      $��1��6E   $
��Left=�6U   $��145,129,0,0q�6p   $
 Wrap=�6�   $	��Top=�6�   $	��203��6�   $��20(�6�   $	 200��6�   $��62��6�   �� 5d      -   5        $ comboBoxEditCategory��5d      $ 0��6=   $��1��6O   $
��Left=�6_   $��147,196,0,0q�6z   $	��Top=�6�   $	��202��6�   $��32��6�   $��20(�6�   �� 5e      -   5        $ textBoxEditPrice��5e      $��1��68   $
��Left=�6H   $��146,327,0,0q�6c   $
 Wrap=�6x   $	��Top=�6�   $	��202��6�   $��20(�6�   $��29��6�   $ 9��6�   �� 5f      -   5        $ comboBoxHasInGarbage��5f      $��1��6=   $
��Left=�6M   $��146,256,0,0q�6h   $	��Top=�6}   $	��203��6�   $��20(�6�   �� 5g      -   5         ��Name$ imageProduct��5g      $��1��62   $
��Left=�6B   $��99��6]   $��147,377,0,0q�6i   $	��Top=�6~   $	��100��6�   $
��Fill=�6�   �� 5h      -   5        $ textBlockImageBitmap��5h       $y�Hidden=�6>   $��1��6R   $
��Left=�6b   $��298,392,0,0q�6}   $
��Wrap=�6�   $	��Top=�6�   5i      5j      �� 5k      $��Orders��6   .��5l      � ���	#FFE5E5E5 5m      �� 5n      $	��70* �6+   �� 5o      $	��30* �6+   .+�5q        -   5        $ dataGridOrders��5q      $ False��6b   $
 True��6~   $��16(�6�    5r        5s      $	 ID��61   
 6=   �� *Id+  5t      $	 Client login��61   $
 Auto 6e   
 6G   �� *	UserLogin+6e     5u      $	 Courier login��61   $
 Auto 6i   
 6H   �� *CourierLogin+6i     5v      $	 Product��61   $
 Auto 6b   
 6B   �� *ProductName+6b     5w      $	 Status��61   $
 Auto 6`   
 6A   �� *
StatusName+6`     5x      $	 Adress��61   $ * 6\   
 6A   �� *Adress+6\     5y      $	 Comment��61   $ * 6^   
 6B   �� *	Comment+6^     5z      $
	 Date��61   $ * 6^   
 6?   �� *
DateString+6^   5|      �� 5}      -   5        $ buttonUpdateOrder��5}      $��1��68   $��Update list��6H   $
��Left=�6^   $��
234,10,0,0q�6y   $	��Top=�6�   $	��114��6�   $��20(�6�   �� 5~      $��1��6    $
��Left=�60   $��	13,71,0,0q�6K   $
��Wrap=�6^   $��Id��6r   $	��Top=�6|   $��20(�6�   �� 5      $��1��6    $
��Left=�60   $��
13,111,0,0q�6K   $
��Wrap=�6_   $��Category��6s   $	��Top=�6�   $��20(�6�   �� 5�      -   5        $ textBlockOrderId��5�       $��1��6;   $
��Left=�6K   $��
149,70,0,0q�6f   $
��Wrap=�6z   $�� ��6�   $	��Top=�6�   $��20(�6�   �� 5�      -   5        $ comboBoxOrderStatus��5�      $��1��6<   $
��Left=�6L   $��148,110,0,0q�6g   $	��Top=�6|   $	��204��6�   $��20(�6�   �� 5�      -   5        $ buttonEditOrderStatus��5�      $��1��6<   $��Edit status��6L   $
��Left=�6b   $��
13,176,0,0q�6}   $	��Top=�6�   6�   5�      5�      5�      �� 5�   
   -   5        $ textBlockUserStatus��5�      $
��Left=�61   $��	15,10,0,0q�6L   $
��Wrap=�6_   $	��Top=�6s   $��24(�6�   �� 5�   
   -   5        $ textBlockUserLogin��5�      $
��Left=�60   $��	14,38,0,0q�6K   $
��Wrap=�6^   $	��Top=�6r   $��18(�6�   �� 5�   
   -   5        $ textBlockUserName��5�      $
��Left=�6/   $��	15,59,0,0q�6J   $
��Wrap=�6]   $	��Top=�6q   $��18(�6�   �� 5�   
   -    5        $ buttonListOrdersByStatus��5�      $��List orders by status��63   $
��Left=�6S   $��
560,38,0,0q�6n   $	��Top=�6�   6�   �� 5�   
   -!   5        $# buttonListMostPopularProducts��5�      $��List popular products��68   $
��Left=�6X   $��
674,38,0,0q�6s   $	��Top=�6�   6�   �� 5�   
   -"   5        $ buttonListActivityClients��5�      $��List activity clients��64   $
��Left=�6T   $��
795,38,0,0q�6o   $	��Top=�6�   6�   �� 5�   
   -#   5        $ buttonListIncomeByMonths��5�      $��List income by months��63   $
��Left=�6S   $��
899,38,0,0q�6n   $	��Top=�6�   6�   5�      5�      