   M S B A M L   `   `   `  ����@  <Audio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:AudioAudio  5   	       Audio.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Audio     5   	     � Title$  Player��5   	   $	��450��6   $	��800��6%   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $��4* �6   �� 5      �� 5      $��2* �6   .+�5   
   �� -   5         ��Name$ 
OpenFolder��5      $1��+Открыть папку с музыкой��6%   $��20 10q�6G   6V   �� 5   
   -   5         ��Name$ 	TrackList��5      $��1��6%   62   �� 5   
   -   5         ��Name$ Slider��5       �� IsSnapToTickEnabled . $��2��6_   $��Center=�6l   $��20 10q�6�    � Minimum$ 0Q�6�   r� 5   
   -   5         r�Name$ MediaElement��5       r� LoadedBehavior$ Manual=�6-   6l   � 5   
   $��3��6   	 � ColumnDefinitions	 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $��3* �6#   �� 5      �� 5      .+�5      �� -   5        $ BackSong��5      
������ 
������ ��5       �� 5!      $��Images/BackImg.png��6   5#      �� 5$      -   5        $ 	StopPause��5$      
������ 
������ $��1��6\   ��5%      �� 5&      $��Images/PlayImg.png��6   5(      �� 5)      -   5        $ NextSong��5)      
������ 
������ $��2��6[   ��5*      �� 5+      $��Images/NextImg.png��6   5-      �� 5.      -   5        $ 
RepeatSong��5.      
������ 
������ $��3��6]   ��5/      �� 50      $��Images/ReplayImg.png��6   52      �� 53      -	   5        $ 
RandomSong��53      
������ 
������ $��4��6]   ��54      �� 55      $��Images/RandomImg.png��6   57      �� 58      -
   5        
 ��Name$
 CurrentTime��58      $��6��6-   $��6��6=   $
��Wrap=�6J   $��	TextBlock��6^   $	��Top=�6o    �� TextAlignment$ Right=�6�   $y�Hidden=�6�   �� 59      -   5        $
 	FinalTime��59      $��Center=�6+   $��7��6H   $
��Wrap=�6X   $��	TextBlock��6l   $	��Top=�6}   $��80��6�   $y�Hidden=�6�   5:      5<      5=      