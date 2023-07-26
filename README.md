# BarAPIController

BarAPIController is an ASP.NET Core Web API controller that handles operations related to bars associated with restaurants.

## API Routes and Usage

### List All Bars

**Endpoint:** `GET /api/bars`

This endpoint lists all bars.

### Get Details of a Specific Bar

**Endpoint:** `GET /api/bars/{id}`

This endpoint retrieves the details of a specific bar.

### Add a New Bar

**Endpoint:** `POST /api/bars`

This endpoint adds a new bar. The JSON content sent should contain the details of the new bar.

### Update a Specific Bar

**Endpoint:** `PUT /api/bars/{id}`

This endpoint updates a specific bar. The JSON content sent should contain the updated details of the bar.

### Delete a Specific Bar

**Endpoint:** `DELETE /api/bars/{id}`

This endpoint deletes a specific bar.

### Partial Update of a Specific Bar

**Endpoint:** `PATCH /api/bars/{id}`

This endpoint performs a partial update on a specific bar. The JSON content sent should contain the specific fields to be updated.

