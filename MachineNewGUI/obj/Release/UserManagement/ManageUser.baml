   M S B A M L   `   `   `  ���� D  @GALNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:GALNewGUI.UserManagementGALNewGUI.UserManagement  )    #GALNewGUI.UserManagement.ManageUser   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:GALNewGUI.UserManagement       � Title$  
ManageUser��$	��410��$	��600�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � AllowsTransparency . ����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ #007ACC�� � Offset$ 0Q�� $ #FFD500��$	 0.5Q�� $ #00C9FF��$ 1Q�	 � 	Resources	 
 �� MergedDictionaries �� Source�� 
 �� $ ../Resources/Themes.xaml?�%    .��� .+��� $��20q�   PrimaryColorForLogin#��[  
������ $��Segoe UI)�$��1q�.@��� ���� $��➕ Add New User��$��14(� � ToolTip$ Add User��.��� ���#FFE4B5.+���  �� CornerRadius$ 12��
������� �� Padding$ 10q�$��10q�$	��Top=�$��Center=�._�� $	��320�� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��Add New User��$��20(�$
��Bold"�$��Segoe UI)�#��[  $��Center=�$��0,0,0,30q��� $��	Username:��$��1��$��0��$��Center=�$��	0,0,10,10q��� $��1��$��1��$��25�����#F0F0F0$��5q�$��0,0,0,10q��� $��	Password:��$��2��$��0��$��Center=�$��	0,0,10,10q�G� $��2��$��1��$��25�����#F0F0F0$��5q�$��0,0,0,10q��� $��Access Level:��$��3��$��0��$��Center=�$��	0,0,10,10q��� $��3��$��1��$��0,0,0,10q����#F0F0F0$��25��$��2q�$��14(�$��Segoe UI)�#��[  $��1q�#��[  .@��� $��Administrator���� $��Engineer���� $��
Technician���� $��Operator���� $	��Add��$��4��$��2��  ModernButton#��[ �� ���� $�� 🗑 Delete User��$��14(�$ Add User��.��� ���#FFB6C1.+��� $ 12��
�������$ 20q�$��20q�$	��Top=�$��Center=�._�� $	��320�� �� $
��Auto ��� $
��Auto ��� $��30 ��� $
��Auto � �� $
��Auto ��� $��* �.+��� $��0��$��2��$��Delete User��$��24(�$
��Bold"�$��Segoe UI)�#��[  $��Center=�$��0,0,0,30q��� $��	Username:��$��1��$��0��$��Center=�$��0,0,10,0q��� $��1��$��1��$��30�����#F0F0F0$��2q�$��14(�$��Segoe UI)�#��[  $��1q�#��[  .@��� $��Administrator���� $��Engineer���� $��
Technician���� $��Operator���� $��Delete��$��3��$��2��  
stopButton#��[ $��Center=�$	��100���� ���� $�� 🔒 Change Password ��$��14(�$  Change Password ��.��� ���#AFEEEE.+��� $ 12��
�������$ 20q�$��20q�$	��Top=�$��Center=�._�� $	��320�� �� $
��Auto ��� $
��Auto ��� $��10 ��� $
��Auto ��� $��30 ��� $
��Auto � �� $
��Auto ��� $��* �.+��� $��0��$��2��$��Change Password��$��26(�$
��Bold"�$��Segoe UI)�#��[  $��Center=�$��0,0,0,30q��� $��	Username:��$��1��$��0��$��Center=�$��0,0,10,0q��� $��1��$��1��$��20�����#F0F0F0$��2q�$��14(�$��Segoe UI)�#��[  $��1q�#��[  .@��� $��Administrator���� $��Engineer���� $��
Technician���� $��Operator���� $��	Password:��$��3��$��0��$��Center=�$��0,0,10,0q�G� -    G�Name$ PasswordBox��$��3��$��1��$��25���� $��Update��$��5��$��2��#��[ $��Center=�$	��100���� -   $	��✕��$��30��$��30��$��Right=�$	��Top=�$��	0,10,10,0q�
������ #��[  
������ $
��Bold"�$��14(� � Cursor$
 Hand��