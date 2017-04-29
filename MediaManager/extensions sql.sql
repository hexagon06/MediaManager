select distinct extension, count(id) c
from files
group by extension
order by c