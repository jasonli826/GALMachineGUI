   M S B A M L   `   `   `  ����  MachineNewGUI)    #MachineNewGUI.Service.ModBusUtility   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  ModBusUtility��5   	   $
��1366��6   $	��600��6,    � WindowState$ 	Maximized=�69   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ #007ACC��6    � Offset$ 0Q�6+   � 5	      $ #FFD500��6   $	 0.5Q�6+   � 5
      $ #00C9FF��6   $ 1Q�6+   5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $: 4/MachineNewGUI;component/Resources/ScrollViewer.xaml?�6%   %    5      .��5      �� $��Stretch=�6   $��Stretch=�61   $
��Auto=�6M   $
��Auto=�6p   .��5      � .+�5   
   �� -   5        $��Stackpanel1��5      	 �� Orientation$	 Vertical=�6(   .+�5      � .+�5      �� $	 
Horizontal=�6!   .+�5      � .+�5      �� $
��Axis��6'   $	��370��65   $	��600��6B   $��0��6N   $��0��6[   $	��Top=�6k   .��5   "   &   System.Windows.Controls.DataGrid  -   5        $��datagridRobotPoints��5   I   $��0��6,   $��1��69   $	��310��6d   
   RowBackground

 �����   AlternatingRowBackground
 �����   datagridColHeaderStyle   ColumnHeaderStyle# [  6�      AutoGenerateColumns .     Columns 5   &   0  *System.Windows.Controls.DataGridTextColumn  5    *   ,  &System.Windows.Controls.DataGridColumn   Header$ Axis Number��6=      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6R   -   5        	colNumber��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5    p   �� *AxisNo+6�     5!   *   $ RefMovement��6=   $ 2* 6R   -   5        colName�� 5!   n   �� *RefMov+6�     5"   *   $ 	RefPulses��6=   $ 1* 6P   -   5        colX�� 5"   i   �� *
Refpulse+6�   5$   #   5&      5'      � 5)      .+�5*      �� $	 Vertical=�6)   .+�5+   "   � .+�5,   &   �� $��ModBus Comport��6/   $	��260��6G   $
�� 300��6T   $	��Top=�6b   $
��Left=�6z   .��5-   *   �� -   5        $��stackProduct1��5-   5   .+�5.   .   � $��5q�68   .+�5/   2   �� $��5q�6<   	ComPort6P   �� 50   2   $��5q�6:   $	��120��6E   ��6Q   ��  �� Path$ Comport�6q   51   /   � 52   .   $��5q�68   .+�53   2   �� $��5q�6<   
Baudrate6Q   �� 54   2   $��5q�6:   $	��120��6E   ��6Q   �� $ Baudrate�6r   55   /   � 56   .   $��5q�68   .+�57   2   �� $��5q�6<   
DataBits6Q   �� 58   2   $��10,5,5,5q�6:   $	��120��6L   ��6X   �� $ Databits�6y   59   /   � 5:   .   $��5q�68   .+�5;   2   �� $��5q�6<   
Stopbits6Q   �� 5<   2   $��10,5,5,5q�6:   $	��120��6L   ��6X   �� $ Stopbits�6y   5=   /   � 5>   .   $��5q�68   .+�5?   2   �� $��5q�6<   Parity Even6T   5@   /   5A   +   5B   '   �� 5C   &   $��Command��6/   $	��100��6@   $	��300��6M   $��2��6Y   $��2��6f   $��0��6z   $	��Top=�6�   $
��Left=�6�   .��5D   *   � .+�5E   .   �� -   5        $��buttonSave2File��5E   5   $��Save To File��6L     ModernButton#��[ 6c   6�   5G   +   5H   '   5J   #   � 5K   "   .+�5L   &   �� $	��600��60   .��5M   *   �� 
�������$	 Vertical=�6L   .+�5N   .   � 
�������$��5q�6O   .+�5O   2   �� $��10q�6<   $
��Bold"�6H   $��65��6Z   	AXIS No6o   �� 5P   2   -	   5        $��comboboxAxisNo��5P   ;   $��80��6Q   $��5q�6]    �� SelectedIndex$ 0��6h   5Q   3   5R   /   � 5S   .   
�������$��5q�6O   .+�5T   2   �� $��10q�6<   $
��Bold"�6H   $��65��6Z   PR No6l   �� 5U   2   -
   5        $��TxtPrNum��5U   :   $��5q�6J   $��80��6U   6b   �� 5V   2   -   5        $��buttonGetvalue��5V   9   #��[ 6O   .��6�   GET6�   �� 5W   2   $��10q�6<   $
��Bold"�6H   Value In (MM) :6l   �� 5X   2   -   5        $��	TxtResult��5X   :   $��5q�6K   $	��100��6V   6d   5Y   /   5[   +   5]   '   5_   #   5`      5b      5f      5h      � 5j      5l      5n      5o      5p      5q      