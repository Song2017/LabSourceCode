
select sum (decode (t.status, 'T', 1, 0)) t_status, 
 sum(case when t.dat=sysdate then 1 else 0 end) now_date
from 
  (select 1 id, 'T' status, sysdate-1 dat from dual union all
   select 2 id, 'F' status, sysdate-1 dat from dual union all
   select 3 id, 'F' status, sysdate-1 dat from dual union all
   select 4 id, 'T' status, sysdate dat from dual union all
   select 5 id, 'F' status, sysdate dat from dual union all
   select 6 id, 'F' status, sysdate dat from dual 
  ) t;