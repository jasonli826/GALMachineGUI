   M S B A M L   `   `   `  ���� D  @GALNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:GALNewGUI.UserManagementGALNewGUI.UserManagement  $    GALNewGUI.UserManagement.Login   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:GALNewGUI.UserManagement       � Title$  Login��$	��450��$	��400�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 	Resources  �� MergedDictionaries �� Source��  �� $ ../Resources\Themes.xaml?�%    .��� ����  �� 
StartPoint$	 0,0&�	 �� EndPoint$		 1,1&�.��� 
 � Color$
 #007ACC�� � Offset$	 0.0Q�� $
 #00BCD4��$	 0.5Q�� $
 #8BC34A��$	 1.0Q�.+��� ���	#ffffffEE �� CornerRadius$ 16�� �� Padding$ 30q�$��30q����#cccccc$��1q�._��� .+��� $��🔐 Welcome��$��26(�$
��Bold"�$��Segoe UI)�   PrimaryColorForLogin#��[  $��Center=�$��0,0,0,30q��� $��Username���� $ 5��#��[  $��1q�$ 0q�._��� -    ��Name$ UsernameBox�� �� 
IsEditable . $��16(�$��Segoe UI Semibold)�$��40��$
��10,5q����#333$��0q�.@��� $��	Developer���� $��Service���� $��Engineer���� $��	Techician���� $��Operator���� $��Password��$��0,20,0,0q�G� -    G�Name$ PasswordBox��� $��0,20,0,0q�$��Center=� � ColumnDefinitions �� $
��Auto ��� $��20 ��� $
��Auto �.+��� -   $��0��$��Login��  ModernButton#��[ $��10q��� -   $��2��$��Cancel��$	��100��  
stopButton#��[ $��10q��� -   $	��✕��$��30��$��30��$��Right=�$	��Top=�$��	0,10,10,0q�
������ #��[  
������ $
��Bold"� � Cursor$
 Hand��