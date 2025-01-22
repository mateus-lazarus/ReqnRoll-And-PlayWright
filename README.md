# An entrypoint to use Reqnroll and Playwright altogether in a simple way
Some considerations:
- It is configured to NOT be headless, you could change that easily
- Feel free to use my site to test your scripts and play along with reqnroll and playwright. [The Calculator Website](https://mateuslazarus.com/calculator) is specially good for that.
- There are two branches, one with parralellism and other without

## What You Will Learn

By working through this project, you will learn how to:
- Set up a new Reqnroll project (or just download the Reqnroll Quick Start Guide)
- Configure basic settings and dependencies
- Implement Playwright alongside with parallelism and without

This project has been enhanced to demonstrate the use of parallelism and to allow users to access their own sites for testing purposes. These additions provide a more robust and flexible testing environment.

### Parallelism

Parallelism has been implemented to improve the efficiency of test execution. By running tests in parallel, you can significantly reduce the time required to complete your test suite although is will consume more memory! The first optimization is to execute playwright headless.

