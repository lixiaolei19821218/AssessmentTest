   M S B A M L   `   `   `  ����U  QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35[<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkitMicrosoft.Windows.Controls  5   	   I EAssessmentTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AssessmentTestAssessmentTest 5   	      AssessmentTest.MainWindow   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   Hk<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkit    5   	   ,localclr-namespace:AssessmentTest    5   	   -   5        $	��350��5   J   $	��525��6W     � Title  6	   ��  �� Path$ Status� �� StringFormat$ AssessmentTest - {0}�� � 	Resources 5      ( "AssessmentTest.ForegroundConverter   foregroundConverter$ AssessmentTest.StatusConverter  statusConverter-   'Microsoft.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value �� RelativeSource �� 	Converter��%�   &	        &	      '  &     7     5   
   6$     5	   
   6    �� 5
   
   "  6   .�5      ��  � �� 6+   ��  �� *Self+$ Content.Text�8   5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��5q�6   $��Financial Data��6   .��5      � $��5q�6   	 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      
 � ColumnDefinitions
 5      �� 5      $
��Auto �6'   �� 5      .+�5      �� $��Pricing Spec��6   �� 5      -   5        $��comboBoxPricingSpec��5   +   $��1��6    �� DisplayMemberPath$
 Name��6x   ��6F   �� $ Data.PricingSpecRows� �� SelectedIndex 6�   �� $ CurrentPricingSpecIndex��� 5       $��	Timestamp��6   $��1��6,   �� 5!      $��1��6@   $��1��6M   ��6   �� $ Data.TimeStamp�6M   )   #Microsoft.Windows.Controls.DataGrid  5"      $��2��6   $��2��6*      AutoGenerateColumns .     
IsReadOnly . ��6>   ��  �� ElementName$ comboBoxPricingSpec��$ SelectedItem.ContractRows�   Columns 5#      3   -Microsoft.Windows.Controls.DataGridTextColumn  5$      /   )Microsoft.Windows.Controls.DataGridColumn   Header$ 
Expiration��6/   4   .Microsoft.Windows.Controls.DataGridBoundColumn   Binding 6C   �� $ 
Expiration�  5%      $ 
Volatility��6/    6C   �� $ 
Volatility�$ {0:P2}��  5&      $ 
Vol Change��6/    6C   �� $ 	VolChange�$ {0:P2}��  5'      $ Tick Change��6/    6D   �� $ 
TickChange�$ {0:P2}��  5(      $ Reference Future��6/    6I   �� $ ReferenceFuture�5*      5+      5,      �� 5-   
   $��5q�6   $��1��6   ��6)   �� $ Status�# [ ��6�   �� $ SwitchCommand�5.      5/      