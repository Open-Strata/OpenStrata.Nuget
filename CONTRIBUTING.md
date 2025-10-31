# Contributing to OpenStrata.MSBuild.Nuget

Thank you for your interest in contributing to the OpenStrata.MSBuild.Nuget project! We welcome contributions from the community and are grateful for your help in making this project better.

## 🤝 How to Contribute

### Reporting Issues

- **Bug Reports**: Use our [bug report template](.github/ISSUE_TEMPLATE/bug_report.md) to report issues
- **Feature Requests**: Use our [feature request template](.github/ISSUE_TEMPLATE/feature_request.md) to suggest new features
- **Questions**: Start a [discussion](https://github.com/Open-Strata/OpenStrata.Nuget/discussions) for questions and support

### Development Process

1. **Fork** the repository
2. **Clone** your fork locally
3. **Create** a feature branch: `git checkout -b feature/your-feature-name`
4. **Make** your changes
5. **Test** your changes thoroughly
6. **Commit** your changes with a clear message
7. **Push** to your fork: `git push origin feature/your-feature-name`
8. **Create** a Pull Request

### Setting Up Development Environment

#### Prerequisites

- .NET SDK 6.0 or later
- Visual Studio 2022 or VS Code
- Git

#### Getting Started

```bash
# Clone your fork
git clone https://github.com/YOUR-USERNAME/OpenStrata.Nuget.git
cd OpenStrata.Nuget

# Build the solution
dotnet build src/OpenStrata.Nuget.sln

# Run tests (when available)
dotnet test src/OpenStrata.Nuget.sln
```

## 📋 Development Guidelines

### Code Style

- Follow standard C# coding conventions
- Use meaningful variable and method names
- Add XML documentation comments for public APIs
- Keep methods focused and small
- Use consistent indentation (4 spaces)

### Commit Messages

We follow [Conventional Commits](https://www.conventionalcommits.org/) specification:

```
type(scope): description

[optional body]

[optional footer(s)]
```

**Types:**

- `feat`: A new feature
- `fix`: A bug fix
- `docs`: Documentation only changes
- `style`: Changes that do not affect the meaning of the code
- `refactor`: A code change that neither fixes a bug nor adds a feature
- `test`: Adding missing tests or correcting existing tests
- `chore`: Changes to the build process or auxiliary tools

**Examples:**
```
feat(tasks): add new MSBuild task for dependency validation
fix(nuspec): resolve issue with duplicate dependencies
docs(readme): update installation instructions
```

### Testing

- Add unit tests for new functionality
- Ensure all existing tests pass
- Aim for good test coverage of new code
- Test both success and failure scenarios

### Documentation

- Update README.md if your changes affect usage
- Add XML documentation for public APIs
- Update relevant documentation files
- Include examples for new features

## 🔍 Pull Request Process

1. **Description**: Provide a clear description of the changes
2. **Testing**: Describe how you tested your changes
3. **Breaking Changes**: Clearly mark any breaking changes
4. **Documentation**: Update documentation as needed
5. **Review**: Address feedback from code reviewers

### Pull Request Template

When creating a pull request, please include:

- **Summary**: Brief description of changes
- **Type of Change**: Bug fix, new feature, breaking change, etc.
- **Testing**: How you tested the changes
- **Checklist**: Complete the PR checklist

## 🏷️ Issue Labels

We use the following labels to categorize issues:

- `bug`: Something isn't working
- `enhancement`: New feature or request
- `documentation`: Improvements or additions to documentation
- `good first issue`: Good for newcomers
- `help wanted`: Extra attention is needed
- `question`: Further information is requested
- `wontfix`: This will not be worked on

## 🎯 Areas for Contribution

We especially welcome contributions in these areas:

### High Priority
- **Unit Testing**: Help us build a comprehensive test suite
- **Documentation**: Improve examples and guides
- **Bug Fixes**: Address issues in the backlog

### Medium Priority
- **Performance Improvements**: Optimize build tasks
- **New Features**: Extend MSBuild task capabilities
- **Integration Examples**: Show integration with different project types

### Future Ideas
- **Visual Studio Templates**: Project templates for common scenarios
- **PowerShell Cmdlets**: PowerShell wrappers for common operations
- **Documentation Site**: Enhanced documentation website

## 🔐 Security

If you discover a security vulnerability, please do not open a public issue. Instead, email us at security@openstrata.org with details of the vulnerability.

## 💬 Communication

- **GitHub Discussions**: General questions and community discussions
- **GitHub Issues**: Bug reports and feature requests
- **Pull Requests**: Code contributions and reviews

## 📜 Code of Conduct

This project adheres to our [Code of Conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code.

## 🏆 Recognition

Contributors will be recognized in our:
- README.md Contributors section
- Release notes for significant contributions
- Annual contributor appreciation posts

## 🤔 Questions?

If you have questions about contributing, please:
1. Check existing [discussions](https://github.com/Open-Strata/OpenStrata.Nuget/discussions)
2. Create a new discussion
3. Reach out to maintainers in the discussions

Thank you for contributing to OpenStrata! 🚀