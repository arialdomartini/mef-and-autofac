
MEF and Autofac
===================

A sample application that shows how to load plugins using the Managed Extensibility Framework MEF provided by [`System.ComponentModel.Composition`](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.composition?view=netframework-4.8) and [Autofac](https://autofac.org/).

It does not use the [Autofac MEF integration](https://docs.autofac.org/en/latest/integration/mef.html), but it register the plugins' Autofac modules with MEF, and then it loads them in the host container.
