--ɾ������Լ��
DECLARE c1 cursor for
    select 'alter table ['+ object_name(parent_obj) + '] drop constraint ['+name+']; '
    from sysobjects
    where xtype = 'F'
open c1
declare @c1 varchar(8000)
fetch next from c1 into @c1
while(@@fetch_status=0)
    begin
        exec(@c1)
        fetch next from c1 into @c1
    end
close c1
deallocate c1
--ɾ�����ݿ����б�
declare @tname varchar(8000)
set @tname=''
select @tname=@tname + Name + ',' from sysobjects where xtype='U'
select @tname='drop table ' + left(@tname,len(@tname)-1)
exec(@tname)