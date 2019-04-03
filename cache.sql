CREATE FUNCTION getNthHighestSalary(N IN NUMBER) RETURN NUMBER IS
result NUMBER;
BEGIN
    /* Write your PL/SQL query statement below */
SELECT  salary into result
FROM Employee e1
WHERE N-1 = (SELECT COUNT(DISTINCT salary) FROM Employee e2
WHERE e2.salary > e1.salary)   and rownum =1 ;
    RETURN result;
END;