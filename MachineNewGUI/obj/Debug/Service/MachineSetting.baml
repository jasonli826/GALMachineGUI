   M S B A M L   `   `   `  ����H  DMachineNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MachineNewGUI.ServiceMachineNewGUI.Service  5   	   *    $MachineNewGUI.Service.MachineSetting   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:MachineNewGUI.Service     5   	   -   5          � Title$  MachineSetting��5   	   $	��550��6    $
��1200��6-   ��5	      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ #007ACC��6    � Offset$ 0Q�6+   � 5      $ #FFD500��6   $	 0.5Q�6+   � 5      $ #00C9FF��6   $ 1Q�6+   5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../Resources/Themes.xaml?�6%   %    5      .��5      � .+�5   
   �� $��20q�6   .@�5      �� ��5      �� 5       �� Orientation$ 
Horizontal=�6!   $��32��6:   .+�5      �� $"��../Images/MachineSetting.png��6    $��20��5      $��20��6   $��Center=�5       �� 5!      $��Machine Setting��6$   $��Center=�5"      $��5,0,0,0q�5#      $��14(�5$      5%      .��5(      �� .��5)      �� $��10q�6!   $ Vertical=�6-   $	��Top=�6D   .+�5,      �� $��10q�6#   
�����F�$��2q�6G   ��5-      �� 5.   "   $��MACHINE CONFIG��6,   $
��Bold"�6B   $��20(�6T   
�������
����  �	 �� Padding$
	 10,4q�5/   F   
 �� TextAlignment$
 Center=�50       $��Stretch=�67   .��53      �� ���#F0F8FF.+�56   "   � $��5q�6,   
�������.+�57   &   �� $��5q�60   $	��220��6;   $��Center=�6G   $��SemiBold"�58      ���#333Machine Type6N   �� 59   &   $��5q�6.   $	��200��69   $��New Machine��6E   {�.  ���#FFEFD5���#6665:   =   5;   #   � 5>   "   $��5q�6,   
�������.+�5?   &   �� $��5q�60   $	��220��6;   $��Center=�6G   $��SemiBold"�5@      ���#333Machine SNo6M   �� 5A   &   $��5q�6.   $	��200��69   $��New Machine 101��6E   ���#FFF8DC5B      5C   #   � 5E   "   $��5q�6,   
�������.+�5F   &   �� $��5q�60   $	��220��6;   $��Center=�6G   $��SemiBold"�5G   %   ���#333
Robot IP6W   �� 5H   &   $��5q�6.   $	��200��69   $��192.168.20.142��6E   ���#FFF8DC5I   &   5J   #   � 5K   "   $��5q�6,   
�������.+�5L   &   �� $��5q�60   $	��220��6;   $��Center=�6G   $��SemiBold"�5M   %   ���#333Robot Port No6\   �� 5N   &   $��5q�6.   $	��200��69   $
��2001��6E   ���#FFF8DC5O   &   5P   #   � 5S   "   -   5        $��WrapDeveloperMode��5S   ,   $��5q�6E   
�������$y�Visible=�6g   .+�5T   &   �� $��5q�60   $	��280��6;   $��Center=�6G   $��SemiBold"�5U      ���#333&$Has Developer Vision Offline Testing6f   �� 5V   &   -   5        $��ChkDeveloperMode��5V   /   $��5q�6G   $��Center=�5W      
���  �� d� 	IsChecked 5V   R   �� *HasDeveloperMode+5W   2   5X   #   5Z      5[      �� 5\      $��5,10,0,0q�6%   $ 
Horizontal=�67   $��Center=�6P   .+�5]      �� $
��Save��6%      ModernButton#��[  64   $��0,0,10,0q�6Z   �� 5^      $��Cancel��6%     
stopButton#��[ 66   5_      5`      5a      5b      �� 5c      ��5d      �� 5e      $ 
Horizontal=�6!   $��32��6:   .+�5f      �� $��../Images/Scanner.png��6    $��20��5g      $��20��6#   $��Center=�5h      �� 5i      $��Scanner Comm Port��6$   $��Center=�5j      $��5,0,0,0q�5k      $��14(�5l      5m      .��5p      �� .��5q      �� $��10q�6!   $ Vertical=�6-   $	��Top=�6D   .+�5t      �� $��10q�6#   
�����F�$��2q�6G   ��5u      �� 5v   "   $��SCANNER COM PORT��6,   $
��Bold"�6D   $��18(�6V   
�������
��� ���$	 8q�5w   ;   $��Stretch=�5x      $
 Center=�62   .��5{      �� ���#F0F8FF.+�5~   "   � -   5        $��WrapScanner1��5~   ,   ���#E6F2FF$��5q�6U   .+�5   &   �� $ 
Horizontal=�61   .+�5�   *   � .+�5�   .   �� $��5q�68   $	��150��6C   $��SemiBold"�6O   ���#333RBT EF Scanner :6�   5�   +   � 5�   *   .+�5�   .   �� -   5         ��Name$ sp_scanner1Serial��5�   R   $ 
Horizontal=�69   ���#F5FFFA$��3q�6�   .+�5�   2   �� $��5q�6<   $��40��6G   $��Right=�6R   ���#333COM6�   �� 5�   2   $��5q�6:   $	��100��6E   $��1��6Q   ���#F0FFF06Z   �� 5�   2   $��5q�6<   $	��100��6G   ���#333
Baudrate6o   �� 5�   2   $��5q�6:   $	��100��6E   $
��9600��6Q   ���#F0FFF06]   5�   /   �� 5�   .   $ 
Horizontal=�69   $��3q�6R   .+�5�   2   �� $��5q�6<   $	��100��6G   ���#333Model6l   �� 5�   2   -   5        $��comboboxloader1��5�   ;   $	��190��6R   $��5q�6^   $��25��6i   
�������6w   5�   /   5�   +   5�   '   5�   #   � 5�   "   -   5        $��WrapScanner2��5�   ,   ���#E6FFE6$��5q�6U   .+�5�   &   �� $ 
Horizontal=�61   .+�5�   *   � .+�5�   .   �� $��5q�68   $	��150��6C   $��SemiBold"�6O   ���#333Fixed Scanner :6�   5�   +   � 5�   *   .+�5�   .   �� -   5        $ sp_scanner2Serial��5�   R   $ 
Horizontal=�69   ���#F0FFF0$��3q�6�   .+�5�   2   �� $��5q�6<   $��40��6G   $��Right=�6R   ���#333COM6�   �� 5�   2   $��5q�6:   $	��100��6E   $��1��6Q   ���#F0FFF06Z   �� 5�   2   $��5q�6<   $	��100��6G   ���#333
Baudrate6o   �� 5�   2   $��5q�6:   $	��100��6E   $
��9600��6Q   ���#F0FFF06]   5�   /   �� 5�   .   $ 
Horizontal=�69   $��3q�6R   .+�5�   2   �� $��5q�6<   $	��100��6G   ���#333Model6l   �� 5�   2   -	   5        $��comboboxloader2��5�   ;   $	��190��6R   $��5q�6^   $��25��6i   
�������6w   5�   /   5�   +   5�   '   5�   #   � 5�   "   $��5q�6,   .+�5�   &   �� $��5q�60   $��Italic$�6;   
���iii�%#DataBits 7, Parity Even, Stop bit 15�   '   5�   #   5�      5�      �� 5�      $��5,10,0,0q�6%   $ 
Horizontal=�67   $��Center=�6P   .+�5�      �� $
��Save��6%   #��[  64   $��0,0,10,0q�6Z   �� 5�      -
   5        $��Cancel��5�   %   #��[ 66   6Z   5�      5�      5�      5�      �� 5�      ��5�      �� 5�      $ 
Horizontal=�6!   $��32��6:   .+�5�      �� $��../Images/Light.png��6    $��20��5�      $��20��6   $��Center=�5�      �� 5�      $��TOWER LIGHT CONFIG��6$   $��Center=�5�      $��5,0,0,0q�5�      $��14(�5�      5�      .��5�      �� -   5         ��Name$ gblightconfig��5�      $��10q�62   $��10q�6?   ���	#FFFDF5E6
��� ���$��2q�6w   ��5�      �� 5�      $��TOWER LIGHT CONFIG��6$   $
��Bold"�5�      $��22(�5�      
��� ���$��Center=�5�      $	��0,5q�5�      .��5�      �� .+�5�      A�  A� Rows$ 1��6&    A� Columns$ 7��6/   $��10,10q�6;   $
��Left=�6J   .+�5�      �� $��State��6(   $	��150��65   $
��Bold"�6A   $��16(�6S   $��Center=�6a   �� 5�      $��Green��6(   $	��150��65   $��16(�6A   $
��Bold"�6O   
�������
���"�"�$
 Center=�6�   $	 5q�6�   �� 5�      $��Amber��6(   $	��150��65   $��16(�6A   $
��Bold"�6O   
���   �
��� ���$
 Center=�6�   $	 5q�6�   �� 5�      $	��Red��6(   $	��150��63   $��16(�6?   $
��Bold"�6M   
�������
���<��$
 Center=�6�   $	 5q�6�   �� 5�      $
��Blue��6(   $	��150��64   $��16(�6@   $
��Bold"�6N   
�������
����iA�$
 Center=�6�   $	 5q�6�   �� 5�      $��Buzzer��6(   $	��150��66   $��16(�6B   $
��Bold"�6P   
���   ����	#FFDDDDDD$
 Center=�6�   $	 5q�6�   �� 5�      $��Reset��5�      #��[ 5�      $
��Bold"�5�      $��5q�5�      $��5q�5�      $��1q�5�       � Cursor$
 Hand��5�      ��5�   %   �� *ResetTowerLightCommand+5�      5�      5�      5�      5�      5�      5�      5�      