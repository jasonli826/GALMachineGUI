   M S B A M L   `   `   `  ���� D  @GALNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:GALNewGUI.EntityGALNewGUI.Entity  -    'GALNewGUI.Controls.ProductHierarchyView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:GALNewGUI.Entity     -   $
��auto��$
��auto��  � 	Resources   �� MergedDictionaries �� Source��  �� $3 -../Resources/ProductViewHierarchy/Themes.xaml?�%    .��� ����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ 	#FF00BFFF�� � Offset$ 0Q�� $ 	#FF8A2BE2��$	 0.5Q�� $ 	#FFFF69B4��$ 1Q�.+�� $��20q� � RowDefinitions �� $
��auto ��� $
��auto ��� $��* �.+��  � Orientation$ 
Horizontal=�$	��Top=�$
��Left=�$��0��.+��� -   $��⬆ Move Up��   ModernButton#��[  $��5q�$
��10,2q�$��30���� -   $��⬇ Move Down��  ModernRedButton#��[ $��10q�$
��10,2q�$��12(�$��30���� -     ImageToolButtonStyle#��[ $
��List��
	 � Tag$	 ../../Images/List.png��$��15q�$��30���� -   #��[ $��Pallet��$	 ../../Images/Pallet.png��$��10q�$��30���� -   #��[ $
��Line��$	 ../../Images/Line.png��$��10q�$��30���� -   #��[ $��Fiducial��$	 ../../Images/Fiducial.png��$��10q�$��30���� -   #��[ $��Barcode��$	 ../../Images/Barcode.png��$��10q�$��30���� -	   #��[ $��InterfaceResult��$&	  ../../Images/InterfaceResult.png��$��10q�$��30���� -
   #��[ $��GripperPlace��$#	 ../../Images/GripperPlace.png��$��10q�$��30���� $��File Extension:��
�������$��18(�$��Center=�$��SemiBold"�$��10,0,5,0q�$y�	Collapsed=�	� -   
 	�Name$
 RbtnJson��$
��JSON�� 	� 	GroupName$ FileExtn��$��34�� d� 	IsChecked$
 TrueY�  ModernRadioButtonStyle#��[ $��18(�$��3q�$y�	Collapsed=�	� -   $
 RbtnXML��$	��XML��$ FileExtn��$ FalseY�$��34��#��[ $��18(�$��3q�$y�	Collapsed=��� -    ��Name$ ExportButton��$��💾 Export��#��[ $��15q�$	��5,2q�$��12(�$��35��$y�	Collapsed=��� -   $ ImportButton��$��📁 Import��#��[  $��3q�$	��5,2q�$��35��$y�	Collapsed=��� $��1��$
��auto��$	��200��$��0,0,0,10q� �� CornerRadius$ 10�����	#33FFFFFF$��1q����	#AAFFFFFF._��� -    ��Name$ UserControlContainer��� $��2�� � ColumnDefinitions �� $
��0.5* ��� $��1* �.+��� $��0��$ 20�� �� Padding$ 15q�$��0,0,10,0q�
�������$��1q����	#33000000  DropShadowEffect J� Effect# [ ._��� .+��� $!��🌳 Product Hierarchy View��
�������$��14(�$
��Bold"�$��0 0 0 10q��� $
��Auto=�
������ $��0q�$	��250��.��R� -   $��TreeViewPalletList��
������ $��0q�$��12(�
������� J� 	AllowDrop .    �� DataType   GALNewGUI.Entity.TreeItem �� ItemsSource �� Orientation �� 
TargetType �� BasedOn��%�   (��       *, +)'Q� �     7Q��� "   �� *
Children+.R��� $ 
Horizontal=�$��3q�
������ .+��� $��18��$��18��$��0,0,5,0q����� *
IconPath+�� 
���   �$��Center=�$��16(����� *Name+�� " Q�8   .�-   �� $��1��$ 20��$ 15q�
�������$��1q����	#33000000# [ ._��� .@��� $��Vision View���� $��Tool Path View��