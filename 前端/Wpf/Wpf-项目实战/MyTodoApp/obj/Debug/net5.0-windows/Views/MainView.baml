   M S B A M L   `   `   `  ????D  @MyTodoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MyTodoApp	MyTodoApp  5   	   ;"clr-namespace:MyTodoApp.ExtensionsMyTodoApp.Extensions  5	   	       MyTodoApp.Views.MainView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:MyTodoApp     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5   	   .ext"clr-namespace:MyTodoApp.Extensions   5	   	   _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 5
   	      MaterialDesignBody#???   5   	   $??Regular"?5   	   $??13(?5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5   	      TextRenderingMode$
 Auto=?5   	     MaterialDesignPaper#???  5   	     MaterialDesignFont#???  5   	    ? Title$ 
MainWindow??5   	   $	??768??6   $
??1280??6)    ? WindowStyle$
 None=?5   	    ? AllowsTransparency$
 True??5   	    ? WindowStartupLocation$ CenterScreen=?5   	   !  Prism.Mvvm.ViewModelLocator   AutoWireViewModel True5   	   .??5      )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ 
DialogHost??5   	      
Identifier$
 Root??5   	   	   DialogTheme$	 Inherit=?5   	   .??5   
   )  #MaterialDesignThemes.Wpf.DrawerHost  -   5        
  Name$
 MyDrawer??5   $      IsLeftDrawerOpen 5      ??  ?? ElementName$ MenuToggleButton?? ?? Path$ 	IsChecked?   LeftDrawerContent 5       ]? 5!      $	??220??6   .+?5"      ?? $	??Top=?6!   $??20q?66   .+?5#      ?? $??/Images/avatar.png??6    $??50??6<   $??50??6G    J? Clip 5$      @? 5%   "    @? Center$ 25 25&?5&   )    @? RadiusX$ 25Q?5'   )    @? RadiusY$ 25Q?5(   )   5)   #   5+      ?? 5,      $??MyText??6$   $??Center=?62   $
??0,10q?6O   5-      ?? 5.      -   5         ??Name$ 	myMenuBar??5.        MyListBoxItemStyle#??[ 6R   ??61   ?? *
MenuBars+* 	 $Microsoft.Xaml.Behaviors.Interaction   Triggers 5/      + 	 %Microsoft.Xaml.Behaviors.EventTrigger  50         	EventName$ SelectionChanged??6-   * 	 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 51   "   2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 68   ?? *NavigateCommand+   CommandParameter 52   %   ?? *SelectedItem+ ?? RelativeSource ??  ?? Mode$ FindAncestor=? ?? AncestorType ListBox53      ??56      ?? 57      .R?58   "   ??  ?? Orientation$ 
Horizontal=?6-   
?????? .+?59   &   '	  !MaterialDesignThemes.Wpf.PackIcon	  $
??15,0q?6>    	  Kind 6L   ?? *Icon+?? 5:   &   $
??10,0q?6G   ??60   ?? *Title+6G   5;   #   5<      5>      5?      .??5A      ?  ? RowDefinitions 5B      ?? 5C      $
??auto ?6$   ?? 5D      .+?5F      '
  !MaterialDesignThemes.Wpf.Snackbar
  -   5         
 Name$ Snackbar??5F   7   $??0??6*     K? ZIndex$  1??6I   ! 
  MessageQueue! 6Z   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  (  "MaterialDesignThemes.Wpf.ColorZone  5H      -   5        "  Name$" 	ColorZone??5I      $??16q?5J      +  %MaterialDesignThemes.Wpf.ShadowAssist#   ShadowDepth$# Depth2=?5K      $   Mode$$ 
PrimaryMid=?5L      $	??Top=?5M      .??5O      ]? $
??True??6    % ? Cursor$
% Hand??65   .+?5P      ?? $??Right=?6%   $ 
Horizontal=?6<   .+?5Q      ?? -   5        & ??Name$& btnMin??5Q   %   $	??━??65    ! MaterialDesignFlatMidBgButton#??[ 6A   6z   ?? 5R      -   5        $& btnMax??5R   %   $	??❐??65   #??[ 6A   6z   ?? 5S      -   5        $& btnClose??5S   %   $	??✖??67   #??[ 6C   6|   5T      '  !MaterialDesignThemes.Wpf.PopupBox  5U      $??Right=?62   '   ToggleContent' 5V      ?? 5W   "   $??/Images/avatar.png??6(   $??25??6D   $??25??6O    5X   &   @? 5Y   *   $ 	12.5 12.5&?5Z   )   $
 12.5Q?5[   )   $
 12.5Q?5\   )   5]   +   5_   #   (   PopupContent.( 5a      ?? .+?5b   "   ?? $??注销??6N   ??6)   ?? *LogingOutCommand+6N   ?? 5c   "   $??个人中心??6N   ??6)   ?? *AppCenterCommand+6N   5d      5e      ?? 5g      $ 
Horizontal=?6%   .+?5i      d? -	   5        ) d?Name$) MenuToggleButton??5j   !    ' #MaterialDesignHamburgerToggleButton#??[ 5k   !   * d? 	IsChecked$* FalseY?5l   !   4  .System.Windows.Automation.AutomationProperties+   Name$+ HamburgerToggleButton??5n   !   ?? 5p      $??24,0,0,0q?5q   !   , ? ToolTip$, Previous Item??5r   !     MaterialDesignToolButton#??[ 5u   !   $
% Hand??5w   ?   ??5s   !   ?? *GoBackCommand+??5t   !   0  *MaterialDesignThemes.Wpf.PackIconExtension  -   Kind$- 	ArrowLeft=?.   Size. 24??5v   !   ??  ?? " ?$ (TextElement.Foreground)?+  %MaterialDesignThemes.Wpf.RippleAssist/   Feedback/ 5w   !   ??  ?? *Self+$ 
Foreground?  BrushRoundConverter0 ?? 	Converter#0 [ 6?   ?? 5y      $??16,0,0,0q?5z   !   $, 	Next Item??5{   !   #??[ 5~   !   $
% Hand??5?   ?   ??5|   !   ?? *GoForwardCommand+??5}   !     $- 
ArrowRight=?. 24??5   !   ??  ?? " ?$ (TextElement.Foreground)?/ 5?   !   ??  ?? *Self+$ 
Foreground?#0 [ 6?   ?? 5?      $??Center=?5?      $??Center=?5?      $??22(?5?      $
??16,0q?5?      $%+ Material Design In XAML Toolkit??5?      $??	笔记本??5?      5?      5?      5?      ?? 5?      $??1??6!   '   !MyTodoApp.Extensions.PrismManager1   MainViewRegionName!  Prism.Regions.RegionManager2   
RegionName#2 Z1 6.   5?      5?      5?      5?      