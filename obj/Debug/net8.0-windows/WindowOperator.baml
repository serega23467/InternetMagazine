   M S B A M L   `   `   `  ����K  GInternetMagazine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:InternetMagazineInternetMagazine  5   	   %    InternetMagazine.WindowOperator   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:InternetMagazine     5   	   $	��700��5   	   $
��1273��6     � WindowStartupLocation$  CenterScreen=�6#   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��15* �6   �� 5      $	��85* �6    � ColumnDefinitions 5   
   �� 5      $	��70* �6   �� 5      $	��30* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridOrders��5      $��1��6V      AutoGenerateColumns$ False��6c      
IsReadOnly$
 True��6   $��16(�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $ Client login��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6Y    6;   �� *	UserLogin+6Y     5      $ Courier login��6%   $
	 Auto 6]    6<   �� *CourierLogin+6]     5      $ Product��6%   $
	 Auto 6V    66   �� *ProductName+6V     5      $ Status��6%   $
	 Auto 6T    65   �� *
StatusName+6T     5      $ Adress��6%   $	 * 6P    65   �� *Adress+6P     5      $ Comment��6%   $	 * 6R    66   �� *	Comment+6R     5      $
 Date��6%   $	 * 6R    63   �� *
DateString+6R   5      �� 5   
   -   5        
 ��Name$
 textBoxOrderComment��5      $��1��6/   $
��Left=�6?   $��
141,79,0,0q�6Z   $��1��6n   $��24(�6{    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��214��6�   $	��144��6�    �� 	MaxLength$	 100��6�   �� 5   
   $��1��6   $
��Left=�6$   $��	10,79,0,0q�6?   $��1��6R   $
��Wrap=�6_   $��Comment��6s   $	��Top=�6�   $��24(�6�   �� 5    
   $��1��6   $
��Left=�6$   $��	10,33,0,0q�6?   $��1��6R   $
��Wrap=�6_   $��Id��6s   $	��Top=�6}   $��24(�6�   �� 5!   
   -   5         ��Name$ textBlockOrderId��5!      $��1��6.   $
��Left=�6>   $��
141,33,0,0q�6Y   $��1��6m   $
��Wrap=�6z   $	��Top=�6�   $��24(�6�   �� 5#   
   -   5         ��Name$ comboBoxOrderStatus��5#      $��1��60   $
��Left=�6@   $��125,279,0,0q�6[   $��1��6p   $	��Top=�6}   $	��231��6�   $��24(�6�   �� 5$   
   $��1��6   $
��Left=�6$   $��
10,279,0,0q�6?   $��1��6S   $
��Wrap=�6`   $��Status��6t   $��24(�6�   $	��Top=�6�   �� 5%   
   -   5         ��Name$ buttonAddComment��5%      $��1��6+   $��Comment��6;   $
��Left=�6M   $��247,443,0,0q�6h   $��1��6}   $	��Top=�6�   $��24(�6�   6�   �� 5&   
   -   5        $ buttonAcceptOrder��5&      $��1��6,   $��Accept order��6<   $
��Left=�6S   $��
42,443,0,0q�6n   $��1��6�   $	��Top=�6�   $��24(�6�   6�   �� 5'   
   -   5        $ buttonUpdateList��5'      $��1��6+   $��Update list��6;   $
��Left=�6Q   $��	33,53,0,0q�6l   $	��Top=�6   $��24(�6�   6�   �� 5)   
   -   5        $ textBlockUserStatus��5)      $
��Left=�61   $��	15,10,0,0q�6L   $
��Wrap=�6`   $	��Top=�6t   $��24(�6�   �� 5*   
   -	   5        $ textBlockUserLogin��5*      $
��Left=�60   $��	14,38,0,0q�6K   $
��Wrap=�6^   $	��Top=�6r   $��18(�6�   �� 5+   
   -
   5        $ textBlockUserName��5+      $
��Left=�6/   $��	15,59,0,0q�6J   $
��Wrap=�6]   $	��Top=�6q   $��18(�6�   5,      5-      