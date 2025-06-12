using Dapper;
using Microsoft.Data.SqlClient;
using Npgsql;
using PipoBerberDesktop.Entities;

public class TransactionRepository
{
    private readonly string _connectionString;

    public TransactionRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Add a new transaction
    public async Task<int> AddTransactionAsync(Transaction transaction)
    {
        const string sql = @"
            INSERT INTO Transactions (type, amount, date, description) 
            VALUES (@Type, @Amount, @Date, @Description);
            SELECT CAST(SCOPE_IDENTITY() as int);";

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QuerySingleAsync<int>(sql, transaction);
    }

    // Get all transactions
    public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
    {
        const string sql = "SELECT * FROM Transactions ORDER BY date DESC, createdAt DESC";

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<Transaction>(sql);
    }

    // Get transactions by date range
    public async Task<IEnumerable<Transaction>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        const string sql = @"
            SELECT * FROM Transactions 
            WHERE date >= @StartDate AND date <= @EndDate 
            ORDER BY date DESC, createdAt DESC";

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<Transaction>(sql, new { StartDate = startDate, EndDate = endDate });
    }

    // Get transactions for a specific month
    public async Task<IEnumerable<Transaction>> GetTransactionsByMonthAsync(int year, int month)
    {
        const string sql = @"
            SELECT * FROM Transactions 
            WHERE YEAR(date) = @Year AND MONTH(date) = @Month 
            ORDER BY date DESC, createdAt DESC";

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<Transaction>(sql, new { Year = year, Month = month });
    }

    // Get transactions for today
    public async Task<IEnumerable<Transaction>> GetTodayTransactionsAsync()
    {
        const string sql = @"
        SELECT * FROM Transactions
        WHERE date = CAST(GETDATE() AS DATE)
        ORDER BY createdAt DESC";

        using var connection = new NpgsqlConnection(_connectionString);
        var result = await connection.QueryAsync<Transaction>(sql);
        return result;
    }

    // Get transaction summary by type
    public async Task<IEnumerable<TransactionSummary>> GetTransactionSummaryAsync(DateTime? startDate = null, DateTime? endDate = null)
    {
        string sql = @"
            SELECT type as Type, SUM(amount) as TotalAmount, COUNT(*) as Count 
            FROM Transactions";

        if (startDate.HasValue && endDate.HasValue)
        {
            sql += " WHERE date >= @StartDate AND date <= @EndDate";
        }

        sql += " GROUP BY type";

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<TransactionSummary>(sql, new { StartDate = startDate, EndDate = endDate });
    }

    // Get monthly reports
    public async Task<IEnumerable<MonthlyReport>> GetMonthlyReportsAsync(int year)
    {
        const string sql = @"
            SELECT 
                YEAR(date) as Year,
                MONTH(date) as Month,
                DATENAME(month, date) as MonthName,
                SUM(CASE WHEN type = 'income' THEN amount ELSE 0 END) as TotalIncome,
                SUM(CASE WHEN type = 'expense' THEN amount ELSE 0 END) as TotalExpenses,
                SUM(CASE WHEN type = 'income' THEN amount ELSE -amount END) as NetAmount
            FROM Transactions 
            WHERE YEAR(date) = @Year
            GROUP BY YEAR(date), MONTH(date), DATENAME(month, date)
            ORDER BY MONTH(date)";

        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<MonthlyReport>(sql, new { Year = year });
    }

    // Update a transaction
    public async Task<bool> UpdateTransactionAsync(Transaction transaction)
    {
        const string sql = @"
            UPDATE Transactions 
            SET type = @Type, amount = @Amount, date = @Date, description = @Description 
            WHERE id = @Id";

        using var connection = new NpgsqlConnection(_connectionString);
        var rowsAffected = await connection.ExecuteAsync(sql, transaction);
        return rowsAffected > 0;
    }

    // Delete a transaction
    public async Task<bool> DeleteTransactionAsync(int id)
    {
        const string sql = "DELETE FROM Transactions WHERE id = @Id";

        using var connection = new NpgsqlConnection(_connectionString);
        var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
        return rowsAffected > 0;
    }

    // Get balance (total income - total expenses) for a date range
    public async Task<decimal> GetBalanceAsync(DateTime? startDate = null, DateTime? endDate = null)
    {
        string sql = @"
            SELECT 
                SUM(CASE WHEN type = 'income' THEN amount ELSE -amount END) as Balance
            FROM Transactions";

        if (startDate.HasValue && endDate.HasValue)
        {
            sql += " WHERE date >= @StartDate AND date <= @EndDate";
        }

        using var connection = new NpgsqlConnection(_connectionString);
        var balance = await connection.QuerySingleOrDefaultAsync<decimal?>(sql, new { StartDate = startDate, EndDate = endDate });
        return balance ?? 0;
    }
}