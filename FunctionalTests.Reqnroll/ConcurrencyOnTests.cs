using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(
    Workers = 0,           // Specific number of workers
    Scope = ExecutionScope.ClassLevel // Method level parallelization
)]