   M S B A M L   `   `   `  ����  GhostLauncher.Client>    8GhostLauncher.Client.Views.Windows.VersionSelectorWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Select Version��5   	    � WindowStartupLocation$ CenterOwner=�6     � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6Z    � SizeToContent$ WidthAndHeight=�6p    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $3 -/ResourceDictionaries/ResourceDictionary.xaml?�6%   %    5
      .��5      �� $��5,10,5,5q�6   .+�5   
   � .+�5      �� $	��200��6j   ��6   �� *VersionCollection+ �� SelectedItem 6A   �� *SelectedVersion+	 �� View	 5      �� 5      .P�5      �� 
 �� Width$	
 200��6)    �� DisplayMemberBinding 65   �� *	Version+��5      �� 5   "   
 � Tag$ Version��67   .��6E   	Version6N   5      �� 5      $
 70��6)    64   �� *ReleaseType+��5      �� 5   "   $ ReleaseType��67   .��6I   Release type6W   5      5      5      5      �� 5!   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   .+�5"      �� $��75��6   $��Cancel��6    $��5q�61   ��6<   �� *CloseCommand+�� 5#      $��75��6   $��OK��6    $��5q�6-   ��68   �� *SelectCommand+5$      5%      5&      