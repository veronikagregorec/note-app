   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    Zapisnik   Zapisnik.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NMahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   -   5          � WindowState$  Normal=�5
   	   $��805.691��6   $
��1200��6/    � WindowStartupLocation$ CenterScreen=�6Z    � 
ResizeMode$ NoResize=�6   
�������.��5      �  � ColumnDefinitions 5   
   �� 5      $	��180 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   $��27��6*   �� 5      $	��610 �6   .+�5   
   � $��2��6   $��Stretch=�6    $��Stretch=�6<   $��	10,0,0,95q�6Z    5      �� 5      $��* �6    .+�5      �� $��Stretch=�6   
�������$��Stretch=�6N   $��0,38,0,0q�6j   .+�5      � .+�5      .  (MahApps.Metro.IconPacks.PackIconMaterial  E AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null�  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null]]   Kind$ FileDocumentBox=�61   $��30��6H   $��30��6S   $��Center=�6_   $��Center=�6z   �� 5      -   5        $
��Novo��5   K   $
��Novo��6      Gumb#��[  6-   6W   5      � 5!      .+�5"        $ ContentSave=�61   $��30��6D   $��30��6O   $��Center=�6[   $��Center=�6v   �� 5#      -   5        $��Shrani��5#   .   $��Shrani��6   #��[  6Q   5$      � 5&      .+�5'        $ Delete=�61   $��30��6?   $��30��6J   $��Center=�6V   $��Center=�6q   �� 5(      -   5        $��Izbriši��5(   /   $��Izbriši��6   #��[  6T   5)      � 5+      .+�5,        $ DeleteForever=�61   $��30��6F   $��30��6Q   $��Center=�6]   $��Center=�6x   �� 5-      -   5        $��počistiZgodovino��5-   /   $��Počisti��6   #��[  6f   5.      � 50      .+�51        $ Brush=�61   $��30��6>   $��30��6I   $��Center=�6U   $��Center=�6p   �� 52      -   5        $��Ozadje��52   C   $��Ozadje��6   #��[  6Q   53      � 55      .+�56        $ CheckboxMarked=�61   $��30��6G   $��30��6R   $��Center=�6^   $��Center=�6y   �� 57      -   5        $��opomnik��57   /   $��Opomnik��6   #��[  6T   58      � 5:      .+�5;        $ FormatAlignJustify=�61   $��30��6K   $��30��6V   $��Center=�6b   $��Center=�6}   �� 5<      -   5        $��predloga��5<   0   $��Predloga��6   #��[  6W   5=      � 5?      .+�5@        $ Printer=�61   $��30��6@   $��30��6K   $��Center=�6W   $��Center=�6r   �� 5A      -	   5        $��Natisni��5A   N   $��Natisni��6   #��[  60   6]   5B      � 5D      .+�5E        $ Email=�61   $��30��6>   $��30��6I   $��Center=�6U   $��Center=�6p   �� 5F      -
   5        $��
posljiMejl��5F   N   $��e-Pošta��6   #��[  60   6`   5G      5H      5I      �� 5K   
   -   5        $��txtBoxNaslov��5L      $
��Left=�5K      $��25,10,0,781q�6.    � ToolTip$ Naslov dokumenta��6C   $��18(�6^   $��Center=�6l   $��1��5L   '   $	��328��67   $��1��6C   �� 5N   
   -   5        $��pisava��5N      $
��Left=�6!      System.Windows.Media.Fonts   SystemFontFamilies#��Z 6<   $	��196��5O      $��378,10,0,781q�6   $��1��65   $��1��6E   (  "System.Windows.Controls.DatePicker  5Q   
   -   5        $��dtPickerNovi��5Q      $
��Left=�6)   $��600,10 ,0,0q�6D   $��1��6Y   $	��Top=�6f   $��2��6~   $��35��6�   $	��196��6�      FirstDayOfWeek$ Monday=�5R      $��Center=�6-   6O   �� 5T   
   -   5        $��txtBoxVsebina��5T   5   $��1��6   $��25,60,25,539q�6   	 �� TextWrapping$
	 Wrap=�6J   
 �� 
AcceptsTab
 .  �� AcceptsReturn . $��18(�6�   $��1��6�   �� 5V   
   -   5        $��iskanjePoBazi��5W      *   $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton . $
��Left=�5V   @   $	��328��6[   $��38��6h   $��
25,328,0,0q�6t   $	��Top=�6�   $��Center=�6�   $ Iskanje po besedi��5W   '   $��1��6D   $��1��6T   $��18(�6a   6o     5Y   
   -   5        $��dtPicker��5Y      $
��Left=�6%   $��378,329,0,0q�6@   $��1��6U   $	��Top=�6b   $��1��6z   $��35��6�   $	��196��6�   $ Monday=�5Z      $��Center=�6-   $ Iskanje po datumu��6�    J� RenderTransformOrigin$ 0.551,2.229&�6�   �� 5\   
   -   5        $��1��5\      $��1��6   $��Odstrani datum��6.   $
��Left=�6G   $	��Top=�6b   $	��120��6z   $��35��6�   $��Center=�5]      $��600,331,0,0q�63   #��[  6H   6i   &   System.Windows.Controls.DataGrid  5_   
   -   5        $��izpisPodatkov��5_   Q   $��1��6   $��25,398,25,95q�6       AutoGenerateColumns . $��1��6f      CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly .    MaxColumnWidth$	 700Q�5`   V   6k   5b      5c      