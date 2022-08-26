# Contributing to open-meteo-dotnet 📃

First of all thank you for reading this!

I really appreciate that you are interested in contributing to this repository. Before you start please make sure to read the relevant sections. It will make it a lot easier to maintain the repository. 🎉

## Table of Contents
 - [Code of Conduct](#code-of-conduct)
 - [I Want To Contribute](#i-want-to-contribute)
   - [Issue Reporting Guidelines](#issue-reporting-guidelines)
   - [Pull Request Guidelines](#pull-request-guidelines)
 - [Style Guideline](#style-guidelines)
   - [Commit Message Convention](#commit-message-convention) 

## Code of Conduct

This project is governed by the [Code of Conduct](https://github.com/aliendwarf/open-meteo-dotnet/blob/master/CODE_OF_CONDUCT.md).

## I Want To Contribute

### Issue Reporting Guidelines
#### Reporting Bugs

- Use the Bug template
- provide as much information as possible
- provide steps to reproduce

#### Suggesting Enhancements

- Enhancement suggestions are tracked as [GitHub issues](github.com/aliendwarf/open-meteo-dotnet/issues).
- Use a **descriptive title** for your issue.
- Provide a **detailed description**.
- Check that your suggestion has not been already added.

### Pull Request Guidelines

- Do not commit directly into the `master` branch. Created a new branch based on `master`. All development should be done in dedicated branches.
- Make sure that all tests pass `CLI: dotnet test` before you open a new Pull Request.
- If adding an Enhancement or a requested feature:
  - Add `(#xxx)` in your Pull Request title if there is an issue related to your PR, e.g. `add new weather location (#1)`
  - Add a testcase, if possible
- If fixing a bug:
  - Add `(fix #xxx)` in your PR title, e.g. `throw error if weatherData is null (fix #10)

## Style Guidelines
### Commit Message Convention

Each commit should contain relatively independent change and the change need to be clarified in the message.

The commit message conventions of this project mainly refers to the most widely used [AngularJS Git Commit Message Conventions](https://docs.google.com/document/d/1QrDFcIiPjSLDn3EL15IJygNPiHORgU1_OOAqWjiDU5Y/edit#heading=h.uyo6cb12dt6w).

Here is the message format:

> `<type>(<scope>): <subject>`
>
> // blank line
>
> `<body>`
>
> // blank line
>
> `<footer>`
