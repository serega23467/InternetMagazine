   M S B A M L   `   `   `  ���� K  GInternetMagazine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:InternetMagazineInternetMagazine  %    InternetMagazine.WindowOperator   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:InternetMagazine     $	��700��$
��1273��  � WindowStartupLocation$  CenterScreen=�.���  � RowDefinitions �� $	��15* ��� $	��85* � � ColumnDefinitions �� $	��70* ��� $	��30* �.+�&   System.Windows.Controls.DataGrid  -     Name$ dataGridOrders��$��1��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��$��16(�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ Client login��	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto  �� *	UserLogin+  $ Courier login��$
	 Auto  �� *CourierLogin+  $ Product��$
	 Auto  �� *ProductName+  $ Status��$
	 Auto  �� *
StatusName+  $ Adress��$	 *  �� *Adress+  $ Comment��$	 *  �� *	Comment+  $
 Date��$	 *  �� *
DateString+�� -   
 ��Name$
 textBoxOrderComment��$��1��$
��Left=�$��
141,79,0,0q�$��1��$��24(� �� TextWrapping$
 Wrap=�$	��Top=�$	��214��$	��144�� �� 	MaxLength$	 100���� $��1��$
��Left=�$��	10,79,0,0q�$��1��$
��Wrap=�$��Comment��$	��Top=�$��24(��� $��1��$
��Left=�$��	10,33,0,0q�$��1��$
��Wrap=�$��Id��$	��Top=�$��24(��� -    ��Name$ textBlockOrderId��$��1��$
��Left=�$��
141,33,0,0q�$��1��$
��Wrap=�$	��Top=�$��24(��� -    ��Name$ comboBoxOrderStatus��$��1��$
��Left=�$��125,279,0,0q�$��1��$	��Top=�$	��231��$��24(��� $��1��$
��Left=�$��
10,279,0,0q�$��1��$
��Wrap=�$��Status��$��24(�$	��Top=��� -    ��Name$ buttonAddComment��$��1��$��Comment��$
��Left=�$��247,443,0,0q�$��1��$	��Top=�$��24(��� -   $ buttonAcceptOrder��$��1��$��Accept order��$
��Left=�$��
42,443,0,0q�$��1��$	��Top=�$��24(��� -   $ buttonUpdateList��$��1��$��Update list��$
��Left=�$��	33,53,0,0q�$	��Top=�$��24(��� -   $ textBlockUserStatus��$
��Left=�$��	15,10,0,0q�$
��Wrap=�$	��Top=�$��24(��� -	   $ textBlockUserLogin��$
��Left=�$��	14,38,0,0q�$
��Wrap=�$	��Top=�$��18(��� -
   $ textBlockUserName��$
��Left=�$��	15,59,0,0q�$
��Wrap=�$	��Top=�$��18(�