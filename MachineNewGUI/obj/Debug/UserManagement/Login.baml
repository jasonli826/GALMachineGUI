   M S B A M L   `   `   `  ����H  DMachineNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:MachineNewGUI.UserManagementMachineNewGUI.UserManagement  5   	   (    "MachineNewGUI.UserManagement.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:MachineNewGUI.UserManagement     5   	     � Title$  Login��5   	   $	��450��6   $	��400��6$    � WindowStartupLocation$ CenterScreen=�60    � 
ResizeMode$ NoResize=�6U    � WindowStyle$
 None=�6k    � AllowsTransparency . 
������  � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../Resources\Themes.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"   	 �� EndPoint$		 1,1&�63   .��5      � 
 � Color$
 #007ACC��6    � Offset$	 0.0Q�6/   � 5      $
 #00BCD4��6   $	 0.5Q�6/   � 5      $
 #8BC34A��6   $	 1.0Q�6/   5      .+�5   
   �� ���	#ffffffEE �� CornerRadius$ 16��6(    �� Padding$ 30q�6:   $��30q�6G   ���#cccccc$��1q�6i   ._�5      �� .+�5      �� $��🔐 Welcome��6   $��26(�6.   $
��Bold"�6<   $��Segoe UI)�6N      PrimaryColorForLogin#��[  6d   $��Center=�6�   $��0,0,0,30q�6�   �� 5!      $��Username��6   �� 5#      #��[  6   $��1q�6N   $ 0q�6b   ._�5$      �� -   5         ��Name$ UsernameBox��5$       �� 
IsEditable .  $��16(�5%      $��Segoe UI Semibold)�6-   $��40��6L   $
��10,5q�6X   $��0q�5&      
��� � �5(      5)      �� 5+      $��Password��6   $��0,20,0,0q�6,   G� 5,      -   5         G�Name$ PasswordBox��5,      � 5-      $��0,20,0,0q�6   $��Center=�6)    � ColumnDefinitions 5.      �� 5/      $
��Auto �6+   �� 50      $��20 �6+   �� 52      $
��Auto �6+   .+�55      �� -   5        $��0��55      $��Login��6-     ModernButton#��[ 6Q   $��10q�6w   �� 57      -   5        $��2��57      $��Cancel��6-   $	��100��6>     
stopButton#��[ 6_   $��10q�6�   58      59      5:      �� 5=   
   -   5        $	��✕��5=      $��30��5>      $��30��6   $��Right=�5?      $	��Top=�5@      $��	0,10,10,0q�5A      
������ #��[  5C      
������ $
��Bold"�5E       � Cursor$
 Hand��5F      5G      5H      5I      