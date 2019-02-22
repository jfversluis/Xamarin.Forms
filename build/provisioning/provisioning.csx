var channel = Env("CHANNEL") ?? "Stable";

if (IsMac)
{
  Item (XreItem.Xcode_10_1_0).XcodeSelect ();
}
<<<<<<< HEAD
Console.WriteLine(channel);
=======

>>>>>>> Update (#12)
XamarinChannel(channel);