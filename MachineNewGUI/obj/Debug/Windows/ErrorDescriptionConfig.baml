   M S B A M L   `   `   `  ����H  DMachineNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MachineNewGUI.WindowPageMachineNewGUI.WindowPage  5   	   5    /MachineNewGUI.WindowPage.ErrorDescriptionConfig   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:MachineNewGUI.WindowPage     5   	   -   5        
�������  � WindowState$  	Maximized=�5   Z    � Title$ ErrorDescriptionConfig��5   	    � WindowStartupLocation$ CenterScreen=�6(    � 	Resources 5	         datagridColHeaderStyleError �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value  datagridRowStyleError)  #System.Windows.Controls.DataGridRow��%�  &	        &	 =    �� 5
   
   "  64   .�5      ��  � ��
 �q�<�6D   �� 5       � ��
 �����6;   �� 5       � ��$ 16(�6)   66   �� 5       � ��
 �q�<�6E   �� 5       � ��$ 1q�60   6<   �� 5       � ��$ Center=�6;   6L   �� 5       � ��$ 30��6'   64   5      �� 5   
   "  6.   .�5      ��  � ��
 �   �6;   �� 5       � ��$ 16(�6)   66   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��datagridErrors��5         RowBackground
 �����	   AlternatingRowBackground
	 �����$��20q�6f   $	��420��6r   
   ColumnHeaderStyle#
 [  6      RowStyle# [ 6�      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Error Code��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 69   -   5        colCode��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   W   �� *	ErrorCode+6�     5       $ Error Message��6%   $
 0.5* 6<   -   5        
colMsg�� .  5    Y   �� *
ErrorMsg+6�     5!      $ Error Description��6%   $ 1* 6@   -   5        colDesc�� 5!   \   �� *ErrorDescription+   EditingElementStyle 5"      �� 5#      " ��6    .�5$      ��  �@��TextWrapping$
 Wrap=�6=   �� 5%       �@��AcceptsReturn . 6>   -   5        5'      5)      5+      �� 5,   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��60��6W   .+�5-      �� -   5         ��Name$ btn_Save��5-        bluebuttonBig#��[ 6'   $��Save All��6e   $��
20,0,20,10q�6x   5.      5/      50      