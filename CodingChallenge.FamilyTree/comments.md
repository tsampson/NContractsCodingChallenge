## Comments
- Original project was set to .netcore 3.0 -> updated to .netcore 9.0
- I'm a big fan of NUnit Tests were written well and easy to implement.
- Added Fluent Assertions nuget package for better readability and assertions.
- Single Linked List was easy to understand
- First Implementation was done using AI (ChatGpt and Github Copilot)
- Tests were failing intermittently. I believe something was wrong in Fizzware NBuilder code. Updated tests to build Once per test run instead of during each test. That seemed to fix the problem.
- After reflection - identified AI implemented Depth First - (explored each child at depth) For large data sets this would not find closest relative very fast.
- Implemented Breadth First Recursion (without AI) and then migrated to not use recursion.

## Scalability and Responsibilities
- Persons could be its own domain. Easily Queryed without have to need to go through Tree structure. Also could be implemented to be very Dynamic/Scalable
- The relationships could be managed in a RelationShips Domain, which could be useful for other types of relationships (IE Organizational Structure) All things that would need to be queried for would need to be added to the node object.
- It's ok to have an api model combine these for UI purposes.
- Prefer to only give back enough information that can fit on a UI page. Implement Paging/Continuous Scrolling.
- Reporting/Large Data should be reserved for a Reporting server as to not cause performance problems for users.
- Too many times I see references or keys on objects that should not have them which cause maintenance nightmares.
- Asked AI for best implementation for persisting FamilyTree graph . . .

directed acyclic graph (DAG)
Adjacency List
Closure Table

I've been impressed with Gits ability to determine if a commit is in a branches history.

Git does do a recursive lookup comparison, but has the ability to have Commit Graph Files (which contains a precomputed index of commits).
