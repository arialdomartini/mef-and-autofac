
MEF and Autofac
===================

A sample application that shows how to load plugins using the Managed Extensibility Framework MEF provided by [`System.ComponentModel.Composition`](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.composition?view=netframework-4.8) and [Autofac](https://autofac.org/).

It does not use the [Autofac MEF integration](https://docs.autofac.org/en/latest/integration/mef.html), but it register the plugins' Autofac modules with MEF, and then it loads them in the host container.

## References

* [Cooperation Between The Autofac and The Microsoft Extensibility Framework](https://kalcik.net/2014/02/09/cooperation-between-the-autofac-and-the-microsoft-extensibility-framework/)
* [Register All Modules Exported Using MEF and Autofac](https://stackoverflow.com/questions/32352672/register-all-modules-exported-using-mef-and-autofac) on StackOverlow
* [Unleashing modules - part 2](http://ondevelopment.blogspot.com/2009/04/unleashing-modules-part-2.html)
* [Bootstrapping an Application with MEF and Autofac](https://buksbaum.us/2009/12/06/bootstrapping-an-application-with-mef-and-autofac/)
