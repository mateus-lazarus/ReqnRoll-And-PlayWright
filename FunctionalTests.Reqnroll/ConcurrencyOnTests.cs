﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(
    Workers = 1,           // Specific number of workers
    Scope = ExecutionScope.MethodLevel // Method level parallelization
)]