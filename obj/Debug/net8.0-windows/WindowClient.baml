   M S B A M L   `   `   `  ����K  GInternetMagazine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:InternetMagazineInternetMagazine  5   	   #    InternetMagazine.WindowClient   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:InternetMagazine     5   	   $	��700��5      $
��1273��6     � WindowStartupLocation$  CenterScreen=�6   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��15* �6   �� 5      $	��85* �6   .+�5   
   �� -   5         ��Name$ textBlockUserStatus��5      $
��Left=�61   $��	15,10,0,0q�6L   $
��Wrap=�6_   $	��Top=�6s   $��24(�6�   �� 5   
   -   5        $ textBlockUserLogin��5      $
��Left=�60   $��	14,38,0,0q�6K   $
��Wrap=�6^   $	��Top=�6r   $��18(�6�   �� 5   
   -   5        $ textBlockUserName��5      $
��Left=�6/   $��	15,59,0,0q�6J   $
��Wrap=�6]   $	��Top=�6q   $��18(�6�   �� 5   
   -   5         ��Name$ 
tabControl��5      $��1��6)    �� SelectedIndex$ 0��66   $��20(�6H   .@�5      �� $��Products��6   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridProducts��5      $��1��65      AutoGenerateColumns$ False��6m      
IsReadOnly$
 True��6�   $��16(�6�      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      	   CellTemplate	 5      �� 5   "   .R�5   &   �� $��50��6K   $��50��6V   $
��Fill=�6b   ��6,   �� *ImageBitmap+6b   5   #   5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Id+  5      $
 Category��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6\    6?   �� *
Category+6\     5      $

 Name��6-   $
 Auto 6[    6;   �� *ProductName+6[     5      $
 Price��6-   $
 Auto 6]    6<   �� *ProductPrice+6]     5       $
 Has in garbage��6-   $
 Auto 6l    6E   �� *HasInGarbageString+6l     5!      $
 Description��6-   $ * 6i    6B   �� *ProductDescription+6i   5#      5$      �� 5%      $��Orders��6   .��5&        -   5        $ dataGridOrders��5&      $ False��6^   $
 True��6z   $��16(�6�    5'        5(      $
 ID��6-    69   �� *Id+  5)      $
 Client login��6-   $
 Auto 6a    6C   �� *	UserLogin+6a     5*      $
 Courier login��6-   $
 Auto 6e    6D   �� *CourierLogin+6e     5+      $
 Product��6-   $
 Auto 6^    6>   �� *ProductName+6^     5,      $
 Status��6-   $
 Auto 6\    6=   �� *
StatusName+6\     5-      $
 Adress��6-   $ * 6X    6=   �� *Adress+6X     5.      $
 Comment��6-   $ * 6Z    6>   �� *	Comment+6Z     5/      $

 Date��6-   $ * 6Z    6;   �� *
DateString+6Z   51      52      53      �� 54   
   -   5         ��Name$ textBoxSearchProduct��54      $
��Left=�60   $��
651,36,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��212��6�   $��24(�6�   6�   �� 55   
   $
��Left=�6   $��
560,38,0,0q�6/   $
��Wrap=�6C   $��Search��6W   $	��Top=�6e   $��24(�6}   �� 56   
   -   5         ��Name$ buttonUpdateList��56      $��Update list��6+   $
��Left=�6A   $��	888,0,0,0q�6\   $��Center=�6o   $��24(�6�   6�   �� 57   
   -	   5        $ buttonOrder��57      $��Order product��6&   $
��Left=�6>   $��1032,32,0,0q�6Y   $	��Top=�6n   $��24(�6�   6�   58      59      