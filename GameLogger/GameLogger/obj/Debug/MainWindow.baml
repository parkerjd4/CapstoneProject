   M S B A M L   `   `   `  ����E  AGameLogger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GameLogger
GameLogger  5   	       GameLogger.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:GameLogger     5   	     � Title$  
GameLogger��5   	   $��622.972��6   $��919.928��6-    � WindowStartupLocation$ CenterScreen=�6=   .��5	      � -   5         �Name$ gridView��5	       � ColumnDefinitions 5
   
   �� 5      $	��18* �6   �� 5      $	��29* �6   .+�5   
   o� -   5         o�Name$ MenuBar��5      $��23��6    $	��Top=�6,   $��2��6D   .@�5      m� $
��File��6   .@�5      m� -   5        $��Add Game��5      6F   m� 5      -   5        $��Remove Game��5      6M   m� 5      -   5        $��Refersh Gamelist��5      6Q   m� 5      -   5        $
��Exit��5      6C   5      5      �� 5   
   -   5        $��gameListImg��5      $��0,23,0,0q�5      $��2��6!   $	��Top=�5      $
��Auto=�6.   $
��Auto=�6^   ��. $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   $��14(�6�   ��5      ��  �� ElementName$ UI�� �� Path$ GameList���5      �� 5      .R�5      A�  A� Columns$ 4��6"   5!      ��5#      �� 5$      	 �� 
TargetType"	 ��6   .�5%      -   5        5&      5(      5,      5.      