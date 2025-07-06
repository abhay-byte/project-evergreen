
# Project Evergreen - GitHub Workflow

This document outlines the official process for contributing code to our project. Following this workflow ensures that our `main` branch is always stable and that all code is reviewed by at least one other person.

**The Golden Rule:** Never commit directly to the `main` branch.

---

## The Feature Branch Workflow Cycle

This is the day-to-day process for all development work.

### Step 1: Get Ready
Before starting any new work, sync your local `main` branch with the remote repository on GitHub.

```bash
# Switch to your local main branch
git checkout main

# Pull the latest changes from GitHub
git pull origin main
```

### Step 2: Create Your Feature Branch
Create a new branch for the task you are about to work on. Name your branch descriptively.

*   **Format:** `<your-name>/<feature-description>`
*   **Example:** `git checkout -b abhay/create-ar-placement-logic`

You are now in a safe, isolated environment.

### Step 3: Do Your Work (Code & Commit)
Write your code, test it, and commit your changes frequently with clear, concise messages.

```bash
# Stage your changed files for a commit
git add .

# Commit your changes with a descriptive message
git commit -m "feat: Add hit-testing logic for AR object placement"
```

### Step 4: Push Your Branch
Periodically push your branch to GitHub to back up your work and make it visible to others.

```bash
# The -u flag is only needed the very first time you push a new branch
git push -u origin abhay/create-ar-placement-logic
```
Subsequent pushes on the same branch can simply be `git push`.

### Step 5: Open a Pull Request (PR)
When your feature is complete and ready for review:
1.  Go to our project's GitHub repository page.
2.  You will see a prompt to create a Pull Request from your recently pushed branch. Click it.
3.  Set the **base branch** to `main`.
4.  Write a clear **title** and **description** for your PR. Explain *what* the PR does and *why*.
5.  On the right-hand side, assign at least one **reviewer** from the team.
6.  Click **"Create pull request"**.

### Step 6: Code Review & Merge
1.  **Review:** Your assigned reviewer will look at your code, test it if necessary, and leave comments or request changes.
2.  **Discuss & Iterate:** Make any requested changes by pushing new commits to your feature branch. The PR will update automatically.
3.  **Approve & Merge:** Once the reviewer approves your changes, you can click the **"Merge pull request"** button. This will merge your feature into the `main` branch.
4.  **Delete Branch:** After merging, GitHub will give you an option to delete your feature branch. This is good practice to keep the repository clean.

This completes the cycle! You are now ready to go back to Step 1 for your next task.
