   M S B A M L   `   `   `  ???? D  @MyTodoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MyTodoApp	MyTodoApp  ;"clr-namespace:MyTodoApp.ExtensionsMyTodoApp.Extensions      MyTodoApp.Views.MainView   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:MyTodoApp     _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   .ext"clr-namespace:MyTodoApp.Extensions   _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	    MaterialDesignBody#???   $??Regular"?$??13(?&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?   TextRenderingMode$
 Auto=?  MaterialDesignPaper#???    MaterialDesignFont#???   ? Title$ 
MainWindow??$	??768??$
??1280?? ? WindowStyle$
 None=? ? AllowsTransparency$
 True?? ? WindowStartupLocation$ CenterScreen=?!  Prism.Mvvm.ViewModelLocator   AutoWireViewModel True.??)  #MaterialDesignThemes.Wpf.DialogHost  -     Name$ 
DialogHost??   
Identifier$
 Root??	   DialogTheme$	 Inherit=?.??)  #MaterialDesignThemes.Wpf.DrawerHost  -   
  Name$
 MyDrawer??   IsLeftDrawerOpen ??  ?? ElementName$ MenuToggleButton?? ?? Path$ 	IsChecked?   LeftDrawerContent ]? $	??220??.+??? $	??Top=?$??20q?.+??? $??/Images/avatar.png??$??50??$??50?? J? Clip @?  @? Center$ 25 25&? @? RadiusX$ 25Q? @? RadiusY$ 25Q??? $??MyText??$??Center=?$
??0,10q??? -    ??Name$ 	myMenuBar??  MyListBoxItemStyle#??[ ???? *
MenuBars+* 	 $Microsoft.Xaml.Behaviors.Interaction   Triggers + 	 %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ SelectionChanged??* 	 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command ?? *NavigateCommand+   CommandParameter ?? *SelectedItem+ ?? RelativeSource ??  ?? Mode$ FindAncestor=? ?? AncestorType ListBox???? .R???  ?? Orientation$ 
Horizontal=?
?????? .+?'	  !MaterialDesignThemes.Wpf.PackIcon	  $
??15,0q? 	  Kind ?? *Icon+?? $
??10,0q????? *Title+.???  ? RowDefinitions ?? $
??auto ??? .+?'
  !MaterialDesignThemes.Wpf.Snackbar
  -    
 Name$ Snackbar??$??0??  K? ZIndex$  1??! 
  MessageQueue! 4  .MaterialDesignThemes.Wpf.MessageQueueExtension  (  "MaterialDesignThemes.Wpf.ColorZone  -   "  Name$" 	ColorZone??$??16q?+  %MaterialDesignThemes.Wpf.ShadowAssist#   ShadowDepth$# Depth2=?$   Mode$$ 
PrimaryMid=?$	??Top=?.??]? $
??True??% ? Cursor$
% Hand??.+??? $??Right=?$ 
Horizontal=?.+??? -   & ??Name$& btnMin??$	??━?? ! MaterialDesignFlatMidBgButton#??[ ?? -   $& btnMax??$	??❐??#??[ ?? -   $& btnClose??$	??✖??#??[ '  !MaterialDesignThemes.Wpf.PopupBox  $??Right=?'   ToggleContent' ?? $??/Images/avatar.png??$??25??$??25?? @? $ 	12.5 12.5&?$
 12.5Q?$
 12.5Q?(   PopupContent.( ?? .+??? $??注销?????? *LogingOutCommand+?? $??个人中心?????? *AppCenterCommand+?? $ 
Horizontal=?.+?d? -	   ) d?Name$) MenuToggleButton?? ' #MaterialDesignHamburgerToggleButton#??[ * d? 	IsChecked$* FalseY?4  .System.Windows.Automation.AutomationProperties+   Name$+ HamburgerToggleButton???? $??24,0,0,0q?, ? ToolTip$, Previous Item??  MaterialDesignToolButton#??[ $
% Hand?????? *GoBackCommand+??0  *MaterialDesignThemes.Wpf.PackIconExtension  -   Kind$- 	ArrowLeft=?.   Size. 24????  ?? " ?$ (TextElement.Foreground)?+  %MaterialDesignThemes.Wpf.RippleAssist/   Feedback/ ??  ?? *Self+$ 
Foreground?  BrushRoundConverter0 ?? 	Converter#0 [ ?? $??16,0,0,0q?$, 	Next Item??#??[ $
% Hand?????? *GoForwardCommand+??  $- 
ArrowRight=?. 24????  ?? " ?$ (TextElement.Foreground)?/ ??  ?? *Self+$ 
Foreground?#0 [ ?? $??Center=?$??Center=?$??22(?$
??16,0q?$%+ Material Design In XAML Toolkit??$??	笔记本???? $??1??'   !MyTodoApp.Extensions.PrismManager1   MainViewRegionName!  Prism.Regions.RegionManager2   
RegionName#2 Z1 