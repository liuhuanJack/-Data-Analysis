   M S B A M L   `   `   `  ����^  ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  5	   	   [ WSystem.Windows.Forms, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5
   	   V RCaliburn.Micro.Tutorial.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:Caliburn.Micro.Tutorial.Wpf.ViewModels&Caliburn.Micro.Tutorial.Wpf.ViewModels 5   	   _4clr-namespace:Caliburn.Micro.Tutorial.Wpf.ViewModels&Caliburn.Micro.Tutorial.Wpf.ViewModels 5   	   /   )Caliburn.Micro.Tutorial.Wpf.Views.ELAView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   UwpfxJhttp://schemas.microsoft.con/winfx/2006/xaml/presentation/toolkit/extended  5   	   ^	 ZCaliburn.Micro.Platform, Version=4.0.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f$microhttp://caliburnmicro.com 	 5   	   YwfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration 	 5	   	   Iwf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms 	 5
   	   E
viewmodels4clr-namespace:Caliburn.Micro.Tutorial.Wpf.ViewModels 	 5   	   @local4clr-namespace:Caliburn.Micro.Tutorial.Wpf.ViewModels 	 5   	   T
 PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;controls,http://metro.mahapps.com/winfx/xaml/controls 
 5   	   (calhttp://www.caliburnproject.org 	 6G     � Title$  ELAView��5   	   $
��1080��6   $
��1920��6'   .��5      �  � RowDefinitions 5   
   �� 5      $	��300 �6   �� 5      $	��200 �6   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 0,1&�67   .��5       �  � Color$ #E0E0E0��6#    � Offset$ 0Q�63   � 5!      $ #F0F0F0��6#   $ 1Q�63   5"      .+�5$      �� $	��5,5q�6   $	��290��6&   .+�5%      �� $ 
Horizontal=�6   .+�5&      �� $��
Start Time��6    $��68��62   $��Arial)�6=   $��14(�6P   $��Center=�6^   7   1System.Windows.Forms.Integration.WindowsFormsHost  5'      $��7,0,0,0q�6+      FontSize$ 14Q�6<   	   
FontFamily$	 Arial)�6J   $	��170��6]   $��22��6i   $��Center=�6u   
   Child.
 5(      )  #System.Windows.Forms.DateTimePicker  -   5        
wfTimeFrom��   Value$ 2023-1-1 12:00:00��5(   @      CustomFormat$ yyyy/MM/dd HH:mm:ss��6Z      Format$ Custom=�6}   6�   5)      5*      �� 5+      $ 
Horizontal=�6   $��0,5,0,0q�66   .+�5,      �� $��End Time��6    $��70��60   $��Arial)�6;   $��14(�6N   $��Center=�6\     5-      $��5,0,0,0q�6+   $ 14Q�6<   $	 Arial)�6J   $	��170��6]   $��22��6i   $��Center=�6u   .
 5.        -   5        wfTimeTo��$ 2023-7-1 12:00:00��5.   >   $ yyyy/MM/dd HH:mm:ss��6X   $ Custom=�6{   6�   5/      50      �� 51      $ Vertical=�6   $��5,5,5,5q�64   .+�52      �� $ 
Horizontal=�6!   $��5,5,5,5q�6:   .+�53      �� $��Chamber��6$   $��70��63   $��Arial)�6>   $��14(�6Q   $��Center=�6_   $��5,5,5,5q�6z   �� 54      -   5         ��Name$ ChamberItems��54   "   $	��100��55      $	��100��6)    �� SelectionMode$ Extended=�66   #��� ��56      $��5,5,5,5q�6d   ��57      �� 58   "   .R�59   &   �� $ 
Horizontal=�61   .+�5:   *   ��  d� 	IsChecked 63   �� *
IsSelected+ �� Mode$ TwoWay=��� 5;   *   $��5,0,0,0q�6M   ��64   �� *	Chamber+6M   5<   '   5=   #   5?      5@      �� 5A      $ 
Horizontal=�6!   $��5,5,5,5q�6:   .+�5B      �� $
��Tool��6$   $��50��60   $��Arial)�6;   $��14(�6N   $��Center=�6\   $��25,5,5,5q�6w   �� 5C      -   5        $ 	ToolItems��5C   "   $	��100��5D   #   $	��100��6/   $ Extended=�6<   #��� ��5E   #   $��5,5,5,5q�6j   ��5F      �� 5G   "   .R�5H   &   �� $ 
Horizontal=�61   .+�5I   *   ��  63   �� *
IsSelected+$ TwoWay=��� 5J   *   $��5,0,0,0q�6J   ��64   �� *Tool+6J   5K   '   5L   #   5N      5O      5P      5Q      �� 5R      $��0,0,5,0q�6   $ Vertical=�6*   ��5S      �� 5T      $	 0,0&�6*   $	 0,1&�6;   .��5U      � $ #E0E0E0��6'   $ 0Q�67   � 5V      $ #F0F0F0��6'   $ 1Q�67   5W      .+�5Y      �� -   5         ��Name$ AddFile��5Y   +   $��AddFile��6   $��5,5,5,5q�6<   $��30��6M   $	��100��6Y   ��5Z      �� 5[      $	 0,0&�6.   $	 0,1&�6?   .��5\      � $ #B3D1F3��6+   $ 0Q�6;   � 5]      $ #80B8E6��6+   $ 1Q�6;   5^      5`      �� 5a      -   5        $ 
LogSummary��5a   /   $��Log Summary��6   $��30��6C   $	��100��6O   $��5,5,5,5q�6[   ��5b      �� 5c      $	 0,0&�6.   $	 0,1&�6?   .��5d      � $ #B3D1F3��6+   $ 0Q�6;   � 5e      $ #80B8E6��6+   $ 1Q�6;   5f      5h      �� 5i      -   5        $ DataCommand��5i   3   $��Show Trace Data��6   $��30��6H   $	��100��6T   $��5,5,5,5q�6`   ��5j      �� 5k      $	 0,0&�6.   $	 0,1&�6?   .��5l      � $ #B3D1F3��6+   $ 0Q�6;   � 5m      $ #80B8E6��6+   $ 1Q�6;   5n      5p      5q      5r      �� 5t   
   $��1��6   $��0��6'   .��5u      �� $��1��6   $��0��6)   $��5,10,0,0q�66   .+�5v      �� $��数据列表��6   $��5q�6(   $��16(�63   $
��Bold"�6A   $��Center=�6S   &   System.Windows.Controls.DataGrid  5w      -   5          Name$ 
RecipeData��5y      $��1��5w      $��0��6+   $��5,10,5,0q�68    �� AlternationCount$ 2��5x         ColumnHeaderHeight$ 30Q�6&      AutoGenerateColumns$ False��6>    %� IsVirtualizing$ False��6Z      CanUserAddRows$ False��5z         CanUserResizeRows$
 True��6(      CanUserResizeColumns$
 True��6A   $��Arial)�6]   $��12(�6p    �� SelectedItem 5y   %   �� *SelectedRecipe+$ TwoWay=�   RowStyle 5{      �� 5|       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    .�5}      ��  �� Property � �� �� Value
 �����6;     �� Triggers  5~      P� 5   "   ! P� Property! �@��AlternationIndex" P� Value$" 1��6S   . �5�   &   ��  � ��
 �����6C   5�   #   5�      #   Columns# 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      ,  &System.Windows.Controls.DataGridColumn$   HeaderTemplate$ 5�      �� 5�   "   .R�5�   &   �� $��Visible��60   $��Arial)�6?   $��12(�6R   $��Bottom=�6`   $��3,0,0,0q�6{   $��50��6�   5�   #   %   CellTemplate% 5�      �� 5�   "   .R�5�   &   ��  	 Caliburn.Micro.Message&   Attach$2& ,[Event Checked] = [Action OnCheckBoxChecked]��5�   /    5�   /   �� *	Visible+$ TwoWay=�' �� UpdateSourceTrigger$' PropertyChanged=�5�   '   5�   #   5�        5�      (   Header$( 
Start Time��61   % 5�      �� 5�   "   .R�5�   &   �� $	��5,0q�6K   $��Arial)�6X   $��14(�6k   $
��Left=�6y   $��Center=�6�   ��60   �� *	StartTime+6�   5�   #   5�        5�      $( End Time��61   % 5�      �� 5�   "   .R�5�   &   �� $	��5,0q�6I   $��Arial)�6V   $��14(�6i   $
��Left=�6w   $��Center=�6�   $
��Auto��6�   ��60   �� *	EndTime+6�   5�   #   5�        5�      $( 	File Name��61   % 5�      �� 5�   "   .R�5�   &   �� $	��5,0q�6J   $��Arial)�6W   $��14(�6j   $
��Left=�6x   $��Center=�6�   $
��Auto��6�   ��60   �� *
FileName+6�   5�   #   5�        5�      $
( Tool��61   % 5�      �� 5�   "   .R�5�   &   �� $	��5,0q�6F   $��Arial)�6S   $��14(�6f   $
��Left=�6t   $��Center=�6�   $
��Auto��6�   ��60   �� *Tool+6�   5�   #   5�        5�      $( Chamber��61   % 5�      �� 5�   "   .R�5�   &   �� $	��5,0q�6I   $��Arial)�6V   $��14(�6i   $
��Left=�6w   $��Center=�6�   $
��Auto��6�   ��60   �� *	Chamber+6�   5�   #   5�        5�      $( Recipe��61   % 5�      �� 5�   "   .R�5�   &   �� $	��5,0q�6H   $��Arial)�6U   $��14(�6h   $
��Left=�6v   $��Center=�6�   $
��Auto��6�   ��60   �� *Recipe+6�   5�   #   5�        5�      $( LotID��61   % 5�      �� 5�   "   .R�5�   &   �� $	��5,0q�6G   $��Arial)�6T   $��14(�6g   $
��Left=�6u   $��Center=�6�   ��60   �� *LotID+6�   5�   #   5�        5�      $
( Slot��61   % 5�      �� 5�   "   .R�5�   &   �� $	��5,0q�6F   $��Arial)�6S   $��14(�6f   $
��Left=�6t   $��Center=�6�   ��60   �� *Slot+6�   5�   #   5�        5�      $( Color��61   % 5�      �� 5�   "   .R�5�   &   �� $��30��6-   $	��100��69   $��Center=�6�   $��Center=�6�   ��6E   �� *Color+$ TwoWay=�$' PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction)   Triggers) 5�   *   +	  %Microsoft.Xaml.Behaviors.EventTrigger	  5�   .   * 	  	EventName$* Click��6=   *
  $Microsoft.Xaml.Behaviors.TriggerBase+ 
  Actions.+ 5�   2   " 	 Caliburn.Micro.ActionMessage  ,   
MethodName$, ChangeColorsCommand��6D   -   
Parameters.- 5�   6    	 Caliburn.Micro.Parameter  .   Value. 6D   �� 5�   3   5�   /   5�   '   5�   #   5�      5�      5�      5�      �� 5�   
   $��1��6   $��Center=�6$   $	��200��6A   $	��410��6N   .��5�      �� $ Vertical=�6   .+�5�      �� $��参数列表��6   $��5q�6(   $��16(�63   $
��Bold"�6A   $��Center=�6S   �� 5�      -	   5        $ DataListItems��5�      ��5�      �� 5�      .R�5�      �� $ 
Horizontal=�6)   .+�5�   "   ��  6+   �� *
IsSelected+$ TwoWay=��� 5�   "   $��5,0,0,0q�6B   ��6,   �� *Data+��5�   &   �� 5�   *   " ��60     5�   .   �� 5�   2   / �� Binding/ 6>   �� *IsSearchResult+$ TwoWay=�$' PropertyChanged=�0 �� Value0 True6�   .a�5�   6   ��  � ��
 �  ��6S   5�   3   5�   +   5�   #   5�      5�      5�      5�      5�      �� 5�   
   $��2��6   $ 
Horizontal=�6"   $��5,5,5,5q�6;   ��5�      �� 5�      $	 0,0&�6&   $	 0,1&�67   .��5�      � $ #E0E0E0��6#   $ 0Q�63   � 5�      $ #F0F0F0��6#   $ 1Q�63   5      .+�5     �� -
   5        1 ��Name$1 
SearchText��5  "   $	��100��6   $��5,5,5,5q�66   $��Center=�6G   �� 5     -   5        $ SearchCommand��5  %   $��Query��6   $��Right=�6<   $��80��6X   $��30��6c   $��5,5,5,5q�6o   ��5     �� 5     $	 0,0&�6*   $	 0,1&�6;   .��5     � $ #B3D1F3��6'   $ 0Q�67   � 5     $ #80B8E6��6'   $ 1Q�67   5	     5     5     �� 5  
   -   5        2 ��Name$2 
ActiveItem��5     $��1��6-   $��3��6:   $��1��6K   $��20q�6[   5     5     