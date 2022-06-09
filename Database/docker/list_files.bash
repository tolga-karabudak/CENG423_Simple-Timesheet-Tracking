sql_dir=/usr/init_db/init-sql-scripts/
for sql_file in "$sql_dir"/*.sql
do
  echo "$sql_file"
done
