clr-dll-runtime-checks
======================

A toolsuite to test mono runtimes for dll changes compatibility.

Given a 3.5 and 4.0 .net applications. These two applications depend on one assemby - core-lib.dll for example.

Version of core-lib.dll is fixed (2.0.1.0)

There are four instances of core-lib:

# Vanilla (with that instance both applications were built)
# Signed (strong-name applied, but no code changes)
# Changed Unsigned (some non-breaking changes in api introduced)
# Changed Signed (non-breaking changes + strong name)

This toolsuite is capable of running 4 tests, for each of runtimes (3.5 and 4.0). Given one of four instances, test copies dll into application directory. After that application is being run.

Test is PASSed if application exits with 0 code.

Expected results (sample is taken from Microsoft .NET 3.5\4.0 runtime)

# Vanilla - PASS
# Signed - FAIL
# Changed Unsigned PASS
# Changed Signed FAIL
