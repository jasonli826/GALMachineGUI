   M S B A M L   `   `   `  ����D  @GALNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GALNewGUI.ProductGALNewGUI.Product  5   	   #    GALNewGUI.Product.EditProduct   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:GALNewGUI.Product     5   	     � Title$  EditProduct��5   	   $	��600��6   $
��1100��6*   ��5	      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ #007ACC��6    � Offset$ 0Q�6+   � 5      $ #FFD500��6   $	 0.5Q�6+   � 5      $ #00C9FF��6   $ 1Q�6+   5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../Resources/Themes.xaml?�6%   %    5      .��5      � .+�5   
   �� $��20q�6   .@�5      �� ��5      �� 5       �� Orientation$ 
Horizontal=�6!   $��32��6:   .+�5       �� $��../Images/product.png��6    $��20��5!      $��20��6   $��Center=�5"      �� 5#      $��Product��6$   $��Center=�5$      $��5,0,0,0q�5%      $��14(�5&      5'      .��5*      �� .��5+      �� $��10q�6!   $ Vertical=�6-   $	��Top=�6D   .+�5.      �� $��Product Info��6#   $��0,0,0,10q�69   $��10q�6K   .��5/      �� $ 
Horizontal=�6)   $��Center=�6B   .+�50   "   �� $��
File Name:��6,   $��Center=�6>   $	��100��6Y      PrimaryColorForLogin#��[  6e   $��18(�6�   �� 51   "   $	��400��6*   	 �� 
IsReadOnly	 . $��New Product��6H   
��� � �6[   52      53      �� 56      $��Specifications��6#   $��10q�6;   .��57      � $��0q�6#   $
��Left=�6.   
 � ColumnDefinitions
 58   "   �� 59   &   $
��auto �67   �� 5:   &   $
��auto �67   �� 5;   &   $
��auto �67   �� 5<   &   $
��auto �67    � RowDefinitions 5>   "   �� 5?   &   $
��auto �64   �� 5@   &   $
��auto �64   �� 5A   &   $
��auto �64   .+�5C   "   �� $��ModuleFromFactor:��6,   $��0��6E   $��0��6R   $��Center=�6b   #��[  6}   $��18(�6�   �� 5D   "   $��Product Name��6*   $��0��6>   $��1��6K   $	��150��6[   
��� � �6g   �� 5F   "   $��Product Name:��6,   $��0��6A   $��2��6N   $��Center=�6^   #��[  6y   $��18(�6�   �� 5G   "   $
��M500��6*   $��0��66   $��3��6C   $	��150��6S   
��� � �6_   �� 5I   "   $��Length:��6,   $��1��6;   $��0��6H   $��Center=�6X   #��[  6s   $��18(�6�   �� 5J   "   $��1��6*   $��1��63   $��1��6@   $	��150��6P   
��� � �6\   �� 5L   "   $��Height:��6,   $��1��6;   $��2��6H   $��Center=�6X   #��[  6s   $��18(�6�   �� 5M   "   $
��2.15��6*   $��1��66   $��3��6C   $	��150��6S   
��� � �6_   �� 5O   "   $��Width:��6,   $��2��6:   $��0��6G   $��Center=�6W   #��[  6r   $��18(�6�   �� 5P   "   $��2��6*   $��2��63   $��1��6@   $	��150��6P   
��� � �6\   5Q      5R      �� 5S      $��5,10,0,0q�6%   $ 
Horizontal=�67   $��Center=�6P   .+�5T      �� $
��Save��6%     ModernButton#��[ 64   $��0,0,10,0q�6Z   �� 5U      $��Cancel��6%     
stopButton#��[ 66   5V      5W      5X      5Y      �� 5[      ��5\      �� 5]      $ 
Horizontal=�6!   $��32��6:   .+�5^      �� $��../Images/InputTray.png��6    $��20��5_      $��20��6   $��Center=�5`      �� 5a      $��
Input Tray��6$   $��Center=�5b      $��5,0,0,0q�5c      $��14(�5d      5e      .��5h      �� $
��Auto=�6   .��5i      �� $��10q�6!   $ Vertical=�6-   $	��Top=�6D   .+�5l      � $��0,0,0,10q�6   
 5m      �� 5n   "   $��* �63   �� 5o   "   $��* �63   .+�5s      �� $��Tray Grid Configuration��6'   $��10q�6H   $��0,0,10,0q�6U   .��5t   "   �  5u   &   �� 5v   *   $
��Auto �68   �� 5w   *   $
��Auto �68   �� 5x   *   $
��Auto �68   
 5z   &   �� 5{   *   $
��Auto �6;   �� 5|   *   $	��100 �6;   �� 5}   *   $��20 �6;   �� 5~   *   $
��Auto �6;   �� 5   *   $	��100 �6;   .+�5�   &   �� $��Rows:��60   $��0��6=   $��0��6J   $��Center=�6Z   #��[  6v   $��18(�6�   �� 5�   &   $��4��6.   $��0��67   $��1��6D   
��� � �6U   �� 5�   &   $��Columns:��60   $��0��6@   $��3��6M   $��Center=�6]   #��[  6y   $��18(�6�   �� 5�   &   $��2��6.   $��0��67   $��4��6D   
��� � �6U   �� 5�   &   $��
Row Pitch:��60   $��1��6B   $��0��6O   $��Center=�6_   #��[  6{   $��18(�6�   �� 5�   &   $��0��6.   $��1��67   $��1��6D   
��� � �6U   �� 5�   &   $��Column Pitch:��60   $��1��6E   $��3��6R   $��Center=�6b   #��[  6~   $��18(�6�   �� 5�   &   $��0��6.   $��1��67   $��4��6D   
��� � �6U   �� 5�   &   $��Row Offset:��60   $��2��6C   $��0��6P   $��Center=�6`   #��[  6|   $��18(�6�   �� 5�   &   $��0��6.   $��2��67   $��1��6D   
��� � �6U   �� 5�   &   $��Column Offset:��60   $��2��6F   $��3��6S   $��Center=�6c   #��[  6   $��18(�6�   �� 5�   &   $��0��6.   $��2��67   $��4��6D   
��� � �6U   5�   #   5�      �� 5�      $��Module-MID Barcode Offset��6'   $��10q�6J   $��1��6W   $��10,0,0,0q�6g   .��5�   "   �  5�   &   �� 5�   *   $
��Auto �68   �� 5�   *   $
��Auto �68   
 5�   &   �� 5�   *   $
��Auto �6;   �� 5�   *   $	��100 �6;   �� 5�   *   $��20 �6;   �� 5�   *   $
��Auto �6;   �� 5�   *   $	��100 �6;   .+�5�   &   �� $��	Offset.X:��60   $��Center=�6A   $��0��6\   $��0��6i   #��[  6z   $��18(�6�   �� 5�   &   $��0��6/   $��0��68   $��1��6E   
��� � �6V   �� 5�   &   $��	Offset.Y:��60   $��Center=�6A   $��0��6\   $��3��6i   #��[  6z   $��18(�6�   �� 5�   &   $��0��6.   $��0��68   $��4��6E   
��� � �6V   �� 5�   &   $��	Offset.Z:��60   $��Center=�6A   $��1��6]   $��0��6j   #��[  6{   $��18(�6�   �� 5�   &   $��0��6/   $��1��69   $��1��6F   
��� � �6W   �� 5�   &   $��	Offset.U:��60   $��Center=�6A   $��1��6]   $��3��6j   #��[  6{   $��18(�6�   �� 5�   &   $��0��6.   $��1��68   $��4��6E   
��� � �6V   5�   #   5�      5�      � 5�      
 5�      �� 5�   "   $��* �63   �� 5�   "   $��* �63   .+�5�      �� $ ��Tray Barcode Configuration��6'   $��10q�6K   $��0��6X   $��0,0,10,0q�6h   .��5�   "   �  5�   &   �� 5�   *   $
��Auto �68   �� 5�   *   $
��Auto �68   �� 5�   *   $
��Auto �68   
 5�   &   �� 5�   *   $
��Auto �6;   �� 5�   *   $	��100 �6;   �� 5�   *   $��20 �6;   �� 5�   *   $
��Auto �6;   �� 5�   *   $	��100 �6;   .+�5�   &   �� $��Prefix:��60   $��Center=�6@   $��0��6[   $��0��6h   #��[  6y   $��18(�6�   �� 5�   &   $��0��6/   $��Center=�68   $��0��6S   $��1��6`   
��� � �6q   �� 5�   &   $��Barcode:��60   $��90��6@   $��Center=�6K   $��0��6g   $��3��6t   #��[  6�   $��18(�6�   �� 5�   &   $��
InputTray1��6/   $��0��6A   $��4��6N   
��� � �6_   �� 5�   &   $��	Offset.X:��60   $��90��6A   $��Center=�6L   $��1��6g   $��0��6t   #��[  6�   $��18(�6�   �� 5�   &   $��0��6/   $��Center=�69   $��1��6U   $��1��6b   
��� � �6s   �� 5�   &   $��	Offset.Y:��60   $��90��6A   $��Center=�6M   $��1��6i   $��3��6v   #��[  6�   $��18(�6�   �� 5�   &   $��0��6/   $��Center=�69   $��1��6U   $��4��6b   
��� � �6s   �� 5�   &   $��	Offset.Z:��60   $��90��6A   $��Center=�6L   $��2��6h   $��0��6u   #��[  6�   $��18(�6�   �� 5�   &   $��0��6/   $��Center=�69   $��2��6U   $��1��6b   
��� � �6s   �� 5�   &   $��	Offset.U:��60   $��90��6A   $��Center=�6L   $��2��6h   $��3��6u   #��[  6�   $��18(�6�   �� 5�   &   $��0��6/   $��Center=�68   $��2��6T   $��4��6a   
��� � �6r   5�   '   5�      �� 5�      -   5        $��InputTrayHeadTool3��5�   j   $��
Tool Tip 3��6'   $��10q�6;   $��1��6H   $��10,0,0,0q�6X   .��5�   "   �  5�   &   �� 5�   *   $
��Auto �68   �� 5�   *   $
��Auto �68   
 5�   &   �� 5�   *   $
��Auto �6;   �� 5�   *   $	��100 �6;   �� 5�   *   $��20 �6;   �� 5�   *   $
��Auto �6;   �� 5�   *   $	��100 �6;   .+�5�   &   �� $��	Offset.X:��60   $��Center=�6B   $��0��6]   $��0��6j   #��[  6{   $��18(�6�   �� 5�   &   $��0��6/   $��Center=�68   $��0��6S   $��1��6`   
��� � �6q   �� 5�   &   $��	Offset.Y:��60   $��Center=�6A   $��0��6\   $��3��6i   #��[  6z   $��18(�6�   �� 5�   &   $��0��6.   $��Center=�67   $��0��6R   $��4��6_   
��� � �6p   �� 5�   &   $��	Offset.Z:��60   $��Center=�6A   $��1��6\   $��0��6i   #��[  6z   $��18(�6�   �� 5�   &   -   5        $��TxtTool3OffsetZRow0��5�   .   $��0��6I   $��Center=�6R   $��1��6m   $��1��6z   
��� � �6�   �� 5�   &   $��	Offset.U:��60   $��Center=�6A   $��1��6]   $��3��6j   #��[  6{   $��18(�6�   �� 5�   &   $��0��6/   $��Center=�68   $��1��6S   $��4��6`   
��� � �6q   5�   #   5�      5�      �� 5�      $��5,10,0,0q�6%   $ 
Horizontal=�67   $��Center=�6P   .+�5�      �� $
��Save��6%   #��[ 64   $��0,0,10,0q�6Z   �� 5�      $��Cancel��6%   #��[ 66   5�      5�      5�      5�      �� 5�      ��5�      �� 5�      $ 
Horizontal=�6!   $��32��6:   .+�5      �� $��../Images/OutputTray.png��6    $��Uniform=�5     $��Stretch=�5     $
��Auto��5     $
��Auto��5     �� 5     $��Output Tray��6$   $��Center=�5     $��5,0,0,0q�5     5     .��5
     �� $
��Auto=�6   .��5     �� $��10q�6!   $ Vertical=�6-   $	��Top=�6D   .+�5     � $��0,0,0,10q�6   
 5     �� 5  "   $��* �63   �� 5  "   $��* �63   .+�5     �� $��Tray Grid Configuration��6'   $��10q�6H   $��0��6U   $��0,0,10,0q�6e   .��5  "   �  5  &   �� 5  *   $
��Auto �68   �� 5  *   $
��Auto �68   �� 5  *   $
��Auto �68   
 5  &   �� 5  *   $
��Auto �6;   �� 5  *   $	��100 �6;   �� 5  *   $��20 �6;   �� 5   *   $
��Auto �6;   �� 5!  *   $	��100 �6;   .+�5$  &   �� $��Rows:��60   $��0��6=   $��0��6J   $��Center=�6Z   #��[  6v   $��18(�6�   �� 5%  &   $��6��6.   $��0��67   $��1��6D   
��� � �6U   �� 5'  &   $��Columns:��60   $��0��6@   $��3��6M   $��Center=�6]   #��[  6y   $��18(�6�   �� 5(  &   $��2��6.   $��0��67   $��4��6D   
��� � �6U   �� 5*  &   $��
Row Pitch:��60   $��1��6B   $��0��6O   $��Center=�6_   #��[  6{   $��18(�6�   �� 5+  &   $��0��6.   $��1��67   $��1��6D   
��� � �6U   �� 5-  &   $��Column Pitch:��60   $��1��6E   $��3��6R   $��Center=�6b   #��[  6~   $��18(�6�   �� 5.  &   $��0��6.   $��1��67   $��4��6D   
��� � �6U   �� 50  &   $��Row Offset:��60   $��2��6C   $��0��6P   $��Center=�6`   #��[  6|   $��18(�6�   �� 51  &   $��0��6.   $��2��67   $��1��6D   
��� � �6U   �� 53  &   $��Column Offset:��60   $��2��6F   $��3��6S   $��Center=�6c   #��[  6   $��18(�6�   �� 54  &   $��0��6.   $��2��67   $��4��6D   
��� � �6U   55  #   56     �� 59     $��Placement Offset��6'   $��10q�6A   $��1��6N   .��5:  "   �  5;  &   �� 5<  *   $
��Auto �68   �� 5=  *   $
��Auto �68   
 5?  &   �� 5@  *   $
��Auto �6;   �� 5A  *   $	��100 �6;   �� 5B  *   $��20 �6;   �� 5C  *   $
��Auto �6;   �� 5D  *   $	��100 �6;   .+�5G  &   �� $��	Offset.X:��60   $��0��6A   $��0��6N   $��Center=�6^   #��[  6z   $��18(�6�   �� 5H  &   $��0��6.   $��0��67   $��1��6D   
��� � �6U   �� 5J  &   $��	Offset.Y:��60   $��0��6A   $��3��6N   $��Center=�6^   #��[  6z   $��18(�6�   �� 5K  &   $��0��6.   $��0��67   $��4��6D   
��� � �6U   �� 5M  &   $��	Offset.Z:��60   $��1��6A   $��0��6N   $��Center=�6^   #��[  6z   $��18(�6�   �� 5N  &   $��0��6.   $��1��67   $��1��6D   
��� � �6U   �� 5P  &   $��	Offset.U:��60   $��1��6A   $��3��6N   $��Center=�6^   #��[  6z   $��18(�6�   �� 5Q  &   $��0��6.   $��1��67   $��4��6D   
��� � �6U   5R  #   5S     5T     � 5W     
 5X     �� 5Y  "   $��* �63   �� 5Z  "   $��* �63   .+�5^     �� $��Pallet Barcode��6'   $��0��6?   $��0,0,10,0q�6O   $��10q�6a   .��5_  "   � 
 5`  &   �� 5a  *   $
��Auto �6;   �� 5b  *   $	��220 �6;   .+�5e  &   �� $��Barcode:��60   $��Center=�6@   $��0��6[   #��[  6l   $��18(�6�   �� 5f  &   $��OutputPallet1��6.   $��1��6C   
��� � �6T   5g  #   5h     �� 5k     $��Pallet Barcode Scan��6'   $��1��6D   $��10q�6T   {�5l     ��  �� ElementName$ ChkAdapatorScan�� �� Path$ 	IsChecked�.��5m  "   �  5n  &   �� 5o  *   $
��Auto �68   �� 5p  *   $
��Auto �68   
 5r  &   �� 5s  *   $
��Auto �6;   �� 5t  *   $	��100 �6;   �� 5u  *   $��20 �6;   �� 5v  *   $
��Auto �6;   �� 5w  *   $	��100 �6;   .+�5z  &   �� $��	Offset.X:��60   $��0��6A   $��0��6N   $��Center=�6^   #��[  6z   $��18(�6�   �� 5{  &   $��0��6.   $��0��67   $��1��6D   
��� � �6U   �� 5}  &   $��	Offset.Y:��60   $��0��6A   $��3��6N   $��Center=�6^   #��[  6z   $��18(�6�   �� 5~  &   $��0��6.   $��0��67   $��4��6D   
��� � �6U   �� 5�  &   $��	Offset.Z:��60   $��1��6A   $��0��6N   $��Center=�6^   #��[  6z   $��18(�6�   �� 5�  &   $��0��6.   $��1��67   $��1��6D   
��� � �6U   �� 5�  &   $��	Offset.U:��60   $��1��6A   $��3��6N   $��Center=�6^   #��[  6z   $��18(�6�   �� 5�  &   $��0��6.   $��1��67   $��4��6D   
��� � �6U   5�  #   5�     5�     �� 5�     $��5,10,0,0q�6%   $ 
Horizontal=�67   $��Center=�6P   .+�5�     �� $
��Save��6%   #��[ 64   $��0,0,10,0q�6Z   �� 5�     $��Cancel��6%   #��[ 66   5�     5�     5�     5�     �� 5�     ��5�     �� 5�     $ 
Horizontal=�6!   $��32��6:   .+�5�     �� $��../Images/Gripper.png��6    $��Uniform=�5�     $��Stretch=�5�     $
��Auto��5�     $
��Auto��5�     �� 5�     $��Gripper Config��6$   $��Center=�5�     $��5,0,0,0q�5�     5�     .��5�     �� $ Vertical=�6   $��10q�64   .+�5�     � $��0,0,0,10q�6   
 5�     �� 5�     $��* �6/   �� 5�     $��* �6/   .+�5�     �� $��Finger 1 Offset��6#   $��10q�6<   $��0,0,10,0q�6I   .��5�     �  5�  "   �� 5�  &   $
��Auto �64   �� 5�  &   $
��Auto �64   
 5�  "   �� 5�  &   $
��Auto �67   �� 5�  &   $	��100 �67   �� 5�  &   $��20 �67   �� 5�  &   $
��Auto �67   �� 5�  &   $	��100 �67   .+�5�  "   �� $��	Offset.X:��6,   $��0��6=   $��0��6J   $��Center=�6Z   #��[  6v   $��18(�6�   �� 5�  "   $��0��6*   $��0��63   $��1��6@   
��� � �6Q   �� 5�  "   $��	Offset.Y:��6,   $��0��6=   $��3��6J   $��Center=�6Z   #��[  6v   $��18(�6�   �� 5�  "   $��0��6*   $��0��63   $��4��6@   
��� � �6Q   �� 5�  "   $��	Offset.Z:��6,   $��1��6=   $��0��6J   $��Center=�6Z   #��[  6v   $��18(�6�   �� 5�  "   $��0��6*   $��1��63   $��1��6@   
��� � �6Q   �� 5�  "   $��	Offset.U:��6,   $��1��6=   $��3��6J   $��Center=�6Z   #��[  6v   $��18(�6�   �� 5�  "   $��0��6*   $��1��63   $��4��6@   
��� � �6Q   5�     5�     �� 5�     $��Finger 1 Barcode��6#   $��10q�6=   $��1��6J   $��10,0,0,0q�6Z   .��5�     �  5�  "   �� 5�  &   $
��Auto �64   
 5�  "   �� 5�  &   $
��Auto �67   �� 5�  &   $	��200 �67   .+�5�  "   �� $��Barcode:��6,   $��0��6<   $��0��6I   $��Center=�6Y   #��[  6u   $��18(�6�   �� 5�  "   $��Finger1Barcode��6*   $��0��6@   $��1��6M   
��� � �6^   5�     5�     5�     � 5�     
 5�     �� 5�     $��* �6/   �� 5�     $��* �6/   .+�5�     �� $��Finger 2 Offset��6#   $��10q�6<   $��0,0,10,0q�6I   .��5�     �  5�  "   �� 5�  &   $
��Auto �64   �� 5�  &   $
��Auto �64   
 5�  "   �� 5�  &   $
��Auto �67   �� 5�  &   $	��100 �67   �� 5�  &   $��20 �67   �� 5�  &   $
��Auto �67   �� 5�  &   $	��100 �67   .+�5�  "   �� $��	Offset.X:��6,   $��0��6=   $��0��6J   $��Center=�6Z   #��[  6v   $��18(�6�   �� 5�  "   $��0��6*   $��0��63   $��1��6@   
��� � �6Q   �� 5�  "   $��	Offset.Y:��6,   $��0��6=   $��3��6J   $��Center=�6Z   #��[  6v   $��18(�6�   �� 5�  "   $��0��6*   $��0��63   $��4��6@   
��� � �6Q   �� 5�  "   $��	Offset.Z:��6,   $��1��6=   $��0��6J   $��Center=�6Z   #��[  6v   $��18(�6�   �� 5�  "   $��0��6*   $��1��63   $��1��6@   
��� � �6Q   �� 5�  "   $��	Offset.U:��6,   $��1��6=   $��3��6J   $��Center=�6Z   #��[  6v   $��18(�6�   �� 5�  "   $��0��6*   $��1��63   $��4��6@   
��� � �6Q   5�     5�     �� 5�     $��Finger 2 Barcode��6#   $��10q�6=   $��1��6J   $��10,0,0,0q�6Z   .��5�     �  5�  "   �� 5�  &   $
��Auto �64   
 5�  "   �� 5�  &   $
��Auto �67   �� 5�  &   $	��200 �67   .+�5  "   �� $��Barcode:��6,   $��0��6<   $��0��6I   $��Center=�6Y   #��[  6u   $��18(�6�   �� 5  "   $��Finger2Barcode��6*   $��0��6@   $��1��6M   
��� � �6^   5     5     5     �� 5     $��5,10,0,0q�6!   $ 
Horizontal=�63   $��Center=�6L   .+�5     �� $
��Save��6!   #��[ 60   $��0,0,10,0q�6V   �� 5	     $��Cancel��6!   #��[ 62   5
     5     5     �� 5     ��5     �� 5     $ 
Horizontal=�6!   $��32��6:   .+�5     �� $��../Images/Light.png��6    $��Uniform=�5     $��Stretch=�5     $
��Auto��5     $
��Auto��5     �� 5     $��TOWER LIGHT CONFIG��6$   $��Center=�5     $��5,0,0,0q�5     5     .��5     �� -   5         ��Name$ gblightconfig��5     ��5     �� 5     $��TOWER LIGHT CONFIG��6$   $
��Bold"�5  $   $��18(�5  $   
��� ���5   :   .��5"     �� .+�5#     A�  A� Rows$ 1��6&    A� Columns$ 7��5$  &   $
��10,5q�5%  &   $
��Left=�5&  &   .+�5'     �� $��State��6(   $	��150��65   6C   �� 5(     $��Green��6(   
��� d �$	��150��5*  (   
������5+  B   �� 5,     $��Amber��6(   $	��150��5-  (   
��� ���
�������5/  C   �� 50     $	��Red��6(   
���  ��$	��150��51  (   
���\\��6M   �� 53     $
��Blue��6(   $	��150��54  (   
����  �
����·�55  D   �� 57     $��Buzzer��6(   $	��150��58  (   66   �� 59     #��[ 5:  %   ��59  %   �� *ResetTowerLightCommand+.��5:  I   Reset6P   5;     �� 5<     ��6"   �� *LightConfig+��5=     �� 5>  "   .R�5?  &   A� $ 1��62   $ 6��6;   {�6G   �� *
IsEditable+.+�5@  *   �� $	��150��6H   $��Center=�6T   ��62   �� *Name+6q   �� 5A  *   ��63   ��   LightStatus �� Source# [  �� SelectedIndex 5B  3   �� *Green+6U   �� 5C  *   ��63   �� # [  5D  3   �� *Yellow+6V   �� 5E  *   ��63   �� # [  5F  3   �� *Red+6S   �� 5G  *   ��63   �� # [  5H  3   �� *Blue+6T   �� 5I  *   ��63   �� # [  5J  3   �� *Buzzer+6V   5K  '   5L  #   5N     5O     5P     5Q     5c     5e     5f     