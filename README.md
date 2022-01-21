# ParameterStoreReloadRepro

This repository contains a repro sample for the issue https://github.com/aws/aws-dotnet-extensions-configuration/issues/97

While running, the console app consumes a configuration value fetched from the AWS Parameter Store that should be reloaded every second.

If you change the value while the program is running, the new value is not made available to the consuming service.

```
8b45e161-4de5-40fe-8a01-d9f637c0b94c: 42
3adfe477-8831-4bd3-9afb-79100f8d8a0f: 42
37300fcd-e002-44de-a1e3-4432dd5ddd2f: 42
a9a3869b-45e6-42fd-8e8b-382135c0e227: 42
<< change value in console >>
5d15720a-c6b6-4a22-857e-cc3dcb5b26b0: 42
ced37d62-ea12-40ea-aa3c-b90a72168f70: 42
a6daf888-3917-4afa-8eb2-0ddefe392665: 42
95d903e3-8b52-4744-8fb1-2a1ab632fc43: 42
```
