   M S B A M L   `   `   `  ���� K  GInternetMagazine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:InternetMagazineInternetMagazine  #    InternetMagazine.WindowClient   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:InternetMagazine     $	��700��$
��1273��  � WindowStartupLocation$  CenterScreen=�.���  � RowDefinitions �� $	��15* ��� $	��85* �.+��� -    ��Name$ textBlockUserStatus��$
��Left=�$��	15,10,0,0q�$
��Wrap=�$	��Top=�$��24(��� -   $ textBlockUserLogin��$
��Left=�$��	14,38,0,0q�$
��Wrap=�$	��Top=�$��18(��� -   $ textBlockUserName��$
��Left=�$��	15,59,0,0q�$
��Wrap=�$	��Top=�$��18(��� -    ��Name$ 
tabControl��$��1�� �� SelectedIndex$ 0��$��20(�.@��� $��Products��.��&   System.Windows.Controls.DataGrid  -     Name$ dataGridProducts��$��1��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��$��16(�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  	   CellTemplate	 �� .R��� $��50��$��50��$
��Fill=����� *ImageBitmap+0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $
 Category��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto  �� *
Category+  $

 Name��$
 Auto  �� *ProductName+  $
 Price��$
 Auto  �� *ProductPrice+  $
 Has in garbage��$
 Auto  �� *HasInGarbageString+  $
 Description��$ *  �� *ProductDescription+�� $��Orders��.��  -   $ dataGridOrders��$ False��$
 True��$��16(�   $
 ID�� �� *Id+  $
 Client login��$
 Auto  �� *	UserLogin+  $
 Courier login��$
 Auto  �� *CourierLogin+  $
 Product��$
 Auto  �� *ProductName+  $
 Status��$
 Auto  �� *
StatusName+  $
 Adress��$ *  �� *Adress+  $
 Comment��$ *  �� *	Comment+  $

 Date��$ *  �� *
DateString+�� -    ��Name$ textBoxSearchProduct��$
��Left=�$��
651,36,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��212��$��24(��� $
��Left=�$��
560,38,0,0q�$
��Wrap=�$��Search��$	��Top=�$��24(��� -    ��Name$ buttonUpdateList��$��Update list��$
��Left=�$��	888,0,0,0q�$��Center=�$��24(��� -	   $ buttonOrder��$��Order product��$
��Left=�$��1032,32,0,0q�$	��Top=�$��24(�