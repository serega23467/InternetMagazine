   M S B A M L   `   `   `  ���� K  GInternetMagazine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:InternetMagazineInternetMagazine  $    InternetMagazine.WindowManager   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:InternetMagazine     $	��700��$
��1273��  � WindowStartupLocation$  CenterScreen=�.���  � RowDefinitions �� $	��10* ��� $	��90* �.+��� -    ��Name$ 
tabControl��$��1�� �� SelectedIndex$ 0��$��20(�.@��� $��Users��.��� ���	#FFE5E5E5 � ColumnDefinitions �� $	��70* ��� $	��30* �.+�&   System.Windows.Controls.DataGrid  -     Name$ dataGridUsers��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��$��16(�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *Id+  $	 Login��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 
 �� *	UserLogin+  $
	 Role��$
 Auto 
 �� *StatusString+  $
	 Name��$
 Auto 
 �� *
UserName+  $	 Phone number��$ * 
 �� *PhoneNumber+�� -    ��Name$ buttonUpdateUsers��$��1��$��Update list��$
��Left=�$��
234,10,0,0q�$	��Top=�$	��114��$��20(��� $��1��$
��Left=�$��	11,58,0,0q�$
��Wrap=�$��Id��$	��Top=�$��20(��� $��1��$
��Left=�$��	11,90,0,0q�$
��Wrap=�$��Login��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,130,0,0q�$
��Wrap=�$
��Name��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,166,0,0q�$
��Wrap=�$
��Role��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,209,0,0q�$
��Wrap=�$��Phone��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,259,0,0q�$
��Wrap=�$��Password��$	��Top=�$��20(�$	��103���� -    ��Name$ textBlockUserId��$��1��$
��Left=�$��
147,57,0,0q�$
��Wrap=�$�� ��$	��Top=�$��20(��� -    ��Name$ textBoxEditLogin��$��1��$
��Left=�$��
146,89,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��204��$��20(� �� 	MaxLength$ 20���� -   $ textBoxEditName��$��1��$
��Left=�$��145,129,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$ 20���� -    ��Name$ comboBoxEditStatus��$��1��$
��Left=�$��147,166,0,0q�$	��Top=�$	��202��$��32��$��20(��� -   $ textBoxEditPhone��$��1��$
��Left=�$��145,207,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$��29��$ 12���� -	   $ textBoxUserPass��$��1��$
��Left=�$��145,259,0,0q�$	��Top=�$	��203��$��20(�$ 20���� $��
Categories��.��� ���	#FFE5E5E5 �� $	��70* ��� $	��30* �.+�  -
   $ dataGridCategories��$ False��$
 True��$��16(�   $	 ID��
 �� *Id+  $	 Category��$ * 
 �� *CategoryName+�� -   $ buttonUpdateCategories��$��1��$��Update list��$
��Left=�$��
234,10,0,0q�$	��Top=�$	��114��$��20(��� $��1��$
��Left=�$��	13,71,0,0q�$
��Wrap=�$��Id��$	��Top=�$��20(��� $��1��$
��Left=�$��
13,111,0,0q�$
��Wrap=�$��Category��$	��Top=�$��20(��� -   $ textBlockCategoryId��$��1��$
��Left=�$��
149,70,0,0q�$
��Wrap=�$�� ��$	��Top=�$��20(��� -   $ textBoxCategoryName��$��1��$
��Left=�$��148,110,0,0q�$
 Wrap=�$	��Top=�$	��204��$��20(�$ 20���� $��Products��.��� ���	#FFE5E5E5 �� $	��70* ��� $	��30* �.+�  -   $ dataGridProducts��$ False��$
 True��$��16(� 4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate �� .R��� $��50��$��50��$
��Fill=����� *ImageBitmap+  $	 ID��
 �� *Id+  $	 Category��$
 Auto 
 �� *
Category+  $
	 Name��$
 Auto 
 �� *ProductName+  $	 Price��$
 Auto 
 �� *ProductPrice+  $	 Has in garbage��$
 Auto 
 �� *HasInGarbageString+  $	 Description��$ * 
 �� *ProductDescription+�� -   $ buttonUpdateProducts��$��1��$��Update list��$
��Left=�$��
234,10,0,0q�$	��Top=�$	��114��$��20(��� $��1��$
��Left=�$��	11,58,0,0q�$
��Wrap=�$��Id��$	��Top=�$��20(��� $��1��$
��Left=�$��	11,90,0,0q�$
��Wrap=�$
��Name��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,130,0,0q�$
��Wrap=�$��Description��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,196,0,0q�$
��Wrap=�$	��Top=�$��20(�$��Category���� $��1��$
��Left=�$��
12,329,0,0q�$
��Wrap=�$��Price��$	��Top=�$��20(��� $��1��$
��Left=�$��
12,256,0,0q�$
��Wrap=�$��Has in garbage��$	��Top=�$��20(�$	��103���� -   $ textBlockProductId��$��1��$
��Left=�$��
147,57,0,0q�$
��Wrap=�$�� ��$	��Top=�$��20(��� -   $ textBoxEditProductName��$��1��$
��Left=�$��
147,88,0,0q�$
 Wrap=�$	��Top=�$	��201��$��20(�$ 20���� -   $# textBoxEditProductDescription��$��1��$
��Left=�$��145,129,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$	 200��$��62���� -   $ comboBoxEditCategory��$ 0��$��1��$
��Left=�$��147,196,0,0q�$	��Top=�$	��202��$��32��$��20(��� -   $ textBoxEditPrice��$��1��$
��Left=�$��146,327,0,0q�$
 Wrap=�$	��Top=�$	��202��$��20(�$��29��$ 9���� -   $ comboBoxHasInGarbage��$��1��$
��Left=�$��146,256,0,0q�$	��Top=�$	��203��$��20(��� -    ��Name$ imageProduct��$��1��$
��Left=�$��99��$��147,377,0,0q�$	��Top=�$	��100��$
��Fill=��� -   $ textBlockImageBitmap��$y�Hidden=�$��1��$
��Left=�$��298,392,0,0q�$
��Wrap=�$	��Top=��� $��Orders��.��� ���	#FFE5E5E5 �� $	��70* ��� $	��30* �.+�  -   $ dataGridOrders��$ False��$
 True��$��16(�   $	 ID��
 �� *Id+  $	 Client login��$
 Auto 
 �� *	UserLogin+  $	 Courier login��$
 Auto 
 �� *CourierLogin+  $	 Product��$
 Auto 
 �� *ProductName+  $	 Status��$
 Auto 
 �� *
StatusName+  $	 Adress��$ * 
 �� *Adress+  $	 Comment��$ * 
 �� *	Comment+  $
	 Date��$ * 
 �� *
DateString+�� -   $ buttonUpdateOrder��$��1��$��Update list��$
��Left=�$��
234,10,0,0q�$	��Top=�$	��114��$��20(��� $��1��$
��Left=�$��	13,71,0,0q�$
��Wrap=�$��Id��$	��Top=�$��20(��� $��1��$
��Left=�$��
13,111,0,0q�$
��Wrap=�$��Category��$	��Top=�$��20(��� -   $ textBlockOrderId��$��1��$
��Left=�$��
149,70,0,0q�$
��Wrap=�$�� ��$	��Top=�$��20(��� -   $ comboBoxOrderStatus��$��1��$
��Left=�$��148,110,0,0q�$	��Top=�$	��204��$��20(��� -   $ buttonEditOrderStatus��$��1��$��Edit status��$
��Left=�$��
13,176,0,0q�$	��Top=��� -   $ textBlockUserStatus��$
��Left=�$��	15,10,0,0q�$
��Wrap=�$	��Top=�$��24(��� -   $ textBlockUserLogin��$
��Left=�$��	14,38,0,0q�$
��Wrap=�$	��Top=�$��18(��� -   $ textBlockUserName��$
��Left=�$��	15,59,0,0q�$
��Wrap=�$	��Top=�$��18(��� -    $ buttonListOrdersByStatus��$��List orders by status��$
��Left=�$��
560,38,0,0q�$	��Top=��� -!   $# buttonListMostPopularProducts��$��List popular products��$
��Left=�$��
674,38,0,0q�$	��Top=��� -"   $ buttonListActivityClients��$��List activity clients��$
��Left=�$��
795,38,0,0q�$	��Top=��� -#   $ buttonListIncomeByMonths��$��List income by months��$
��Left=�$��
899,38,0,0q�$	��Top=�